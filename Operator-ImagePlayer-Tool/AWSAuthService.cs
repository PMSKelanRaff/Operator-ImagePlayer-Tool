using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.CognitoIdentity;
using Amazon.CognitoIdentityProvider.Model;
using Amazon.CognitoIdentityProvider;
using Amazon.S3.Model;
using Amazon.S3;
using Amazon.SecurityToken.Model;
using Amazon.SecurityToken;
using Amazon;
using System.Windows.Forms;

namespace Operator_ImagePlayer_Tool
{    
    public class AWSAuthService
        {
            private readonly string _userPoolId;
            private readonly string _clientId;
            private readonly string _identityPoolId;
            private readonly string _roleArn;
            private readonly RegionEndpoint _region;

            public AWSAuthService(string userPoolId, string clientId, string identityPoolId, string roleArn, RegionEndpoint region)
            {
                _userPoolId = userPoolId;
                _clientId = clientId;
                _identityPoolId = identityPoolId;
                _roleArn = roleArn;
                _region = region;
            }

            public async Task<AmazonS3Client> LoginAndGetS3ClientAsync(string username, string password)
            {
                try
                {
                    // 1. Authenticate with Cognito User Pool
                    var provider = new AmazonCognitoIdentityProviderClient(_region);
                    var authRequest = new InitiateAuthRequest
                    {
                        AuthFlow = AuthFlowType.USER_PASSWORD_AUTH,
                        ClientId = _clientId,
                        AuthParameters = new Dictionary<string, string>
                    {
                        { "USERNAME", username },
                        { "PASSWORD", password }
                    }
                    };

                    var authResponse = await provider.InitiateAuthAsync(authRequest);
                    string idToken = authResponse.AuthenticationResult.IdToken;

                    // 2. Get temporary AWS credentials from Cognito Identity Pool
                    var credentials = new CognitoAWSCredentials(_identityPoolId, _region);
                    credentials.AddLogin($"cognito-idp.{_region.SystemName}.amazonaws.com/{_userPoolId}", idToken);

                    // 3. Assume PMS role using STS
                    var stsClient = new AmazonSecurityTokenServiceClient(credentials, _region);
                    var assumeRoleResponse = await stsClient.AssumeRoleAsync(new AssumeRoleRequest
                    {
                        RoleArn = _roleArn,
                        RoleSessionName = "ImageViewerSession"
                    });

                    var assumedCreds = assumeRoleResponse.Credentials;

                    // 4. Create S3 client with assumed role credentials
                    return new AmazonS3Client(
                        assumedCreds.AccessKeyId,
                        assumedCreds.SecretAccessKey,
                        assumedCreds.SessionToken,
                        _region
                    );
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("AWS login failed: " + ex.Message, ex);
                }
            }
    }
}
