using Simplifi.BankStatementsAPIDemo.models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;





    namespace Simplifi.BankStatementsAPIDemo
    {
        public class RESTManager
        {
            private static HttpClient client = null;
            private static BlockingCollection<String> throttle = null;

            public enum RequestTypeAction
            {
                identities,
                enroll,
            BankStatementSimpleRequest
        }

            private static readonly Lazy<RESTManager> instance = new Lazy<RESTManager>(() => new RESTManager());
            public static RESTManager Instance
            {
                get
                {
                    if (client == null)
                    {
                        client = new HttpClient();
                        client.Timeout = TimeSpan.FromMilliseconds(5000);
                        throttle = new BlockingCollection<String>(2);

                    }

                    return instance.Value;
                }
            }

            public void SetServiceTimeout(int Milliseconds)
            {
                if (client != null)
                {
                    client.Timeout = TimeSpan.FromMilliseconds(Milliseconds);
                }

            }

            public void SetThrottleNumberOfCores(int NumberOfCores)
            {
                throttle = new BlockingCollection<String>(NumberOfCores);
            }

            public String CallGenericRestPostBasicAutentication<T>(String RestFunction, string GatewayEndpoint, string JSONInput, Dictionary<string, string> HeaderDictionary, String UserName, String Password)
            {
                String s = Task.Run(async () => await callGenericRestPostBasicAuthentication(RestFunction, GatewayEndpoint, JSONInput, HeaderDictionary, UserName, Password)).Result;

                if (s.Trim().Length <= 0)
                {
                    throw new Exception("No result was returned for this WEB API method");
                }


                return s;

            }

            public WebAPIResponse CallGenericRestPostBearerToken<T>(String RestFunction, string GatewayEndpoint, string JSONInput, Dictionary<string, string> HeaderDictionary, String Token)
            {

                WebAPIResponse webAPIResponse = Task.Run(async () => await callGenericRestPostBearerToken(RestFunction, GatewayEndpoint, JSONInput, HeaderDictionary, Token)).Result;


                return webAPIResponse;

            }

            private static async Task<WebAPIResponse> callGenericRestPostBearerToken(String RestFunction, string GatewayEndpoint, string JSONInput, Dictionary<string, string> HeaderDictionary, String Token)
            {
                try
                {

                    Uri uri = new Uri(GatewayEndpoint);
                    ServicePoint sp = ServicePointManager.FindServicePoint(uri);
                    sp.ConnectionLimit = 2;

                    var handler = new System.Net.Http.HttpClientHandler();
                    using (HttpClient client = new HttpClient(handler))
                    {
                    client.Timeout = TimeSpan.FromSeconds(120);
                        handler.ServerCertificateCustomValidationCallback = (request, cert, chain, errors) =>
                        {
                            // Log it, then use the same answer it would have had if we didn't make a callback.
                            Console.WriteLine(cert);
                            //return errors == SslPolicyErrors.None;

                            return true;
                        };
                        client.Timeout = TimeSpan.FromMinutes(3);

                        if (HeaderDictionary != null)
                        {
                            for (int i = 0; i < HeaderDictionary.Keys.Count; i++)
                            {
                                client.DefaultRequestHeaders.Add(HeaderDictionary.ElementAt(i).Key, HeaderDictionary.ElementAt(i).Value);
                            }

                        }

                        //todo
                        client.DefaultRequestHeaders.Authorization =
                            new AuthenticationHeaderValue("Bearer", Token);


                        ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;



                        HttpResponseMessage responsePost = await client.PostAsync(
                        GatewayEndpoint + "/" + RestFunction, new StringContent(JSONInput, System.Text.Encoding.UTF8, "application/json"));
                        string s = await responsePost.Content.ReadAsStringAsync();

                    return new WebAPIResponse((int)responsePost.StatusCode, responsePost.ReasonPhrase, s);
                }



                }
                catch (Exception ex)
                {
                    throw ex;

                }
                finally
                {
                    //throttle.Take();
                }
            }


            private static async Task<String> callGenericRestPostBasicAuthentication(String RestFunction, string GatewayEndpoint, string JSONInput, Dictionary<string, string> HeaderDictionary, String UserName, String Password)
            {
                try
                {

                    Uri uri = new Uri(GatewayEndpoint);
                    ServicePoint sp = ServicePointManager.FindServicePoint(uri);
                    sp.ConnectionLimit = 2;

                    var handler = new System.Net.Http.HttpClientHandler();
                    using (HttpClient client = new HttpClient(handler))
                    {
                        handler.ServerCertificateCustomValidationCallback = (request, cert, chain, errors) =>
                        {
                            // Log it, then use the same answer it would have had if we didn't make a callback.
                            Console.WriteLine(cert);
                            //return errors == SslPolicyErrors.None;

                            return true;
                        };
                        client.Timeout = TimeSpan.FromMinutes(3);

                        if (HeaderDictionary != null)
                        {
                            for (int i = 0; i < HeaderDictionary.Keys.Count; i++)
                            {
                                client.DefaultRequestHeaders.Add(HeaderDictionary.ElementAt(i).Key, HeaderDictionary.ElementAt(i).Value);
                            }

                        }

                        //todo
                        client.DefaultRequestHeaders.Authorization =
                            new AuthenticationHeaderValue("Bearer", "Your Oauth token");

                        client.DefaultRequestHeaders.Authorization =
                                new AuthenticationHeaderValue(
                                        "Basic", Convert.ToBase64String(
                                                System.Text.ASCIIEncoding.ASCII.GetBytes(
                                                $"{UserName}:{Password}")));

                        ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;



                        HttpResponseMessage responsePost = await client.PostAsync(
                        GatewayEndpoint, new StringContent(JSONInput, System.Text.Encoding.UTF8, "application/json"));
                        string s = await responsePost.Content.ReadAsStringAsync();
                        return s;
                    }



                }
                catch (Exception ex)
                {
                    throw ex;

                }
                finally
                {
                    //throttle.Take();
                }
            }

        public String CallGenericGetWithBearerTokenAuthentication(RequestTypeAction RequestType, string GatewayEndpoint, Dictionary<string, string> HeaderDictionary, String Token)
        {
            if (String.IsNullOrEmpty(GatewayEndpoint))
            {
                throw new Exception("Endpoint cannot be empty or null !");
            }

            return Task.Run(async () => await callGenericGetWithBearerTokenAuthentication(RequestType, GatewayEndpoint, HeaderDictionary, Token)).Result;
        }

        private static async Task<String> callGenericGetWithBearerTokenAuthentication(RequestTypeAction RequestType, string GatewayEndpoint, Dictionary<string, string> HeaderDictionary, String Token)
        {
            try
            {
                Uri uri = new Uri(GatewayEndpoint);
                ServicePoint sp = ServicePointManager.FindServicePoint(uri);
                sp.ConnectionLimit = 2;

                var handler = new System.Net.Http.HttpClientHandler();
                using (HttpClient client = new HttpClient(handler))
                {
                    handler.ServerCertificateCustomValidationCallback = (request, cert, chain, errors) =>
                    {
                        // Log it, then use the same answer it would have had if we didn't make a callback.
                        Console.WriteLine(cert);
                        //return errors == SslPolicyErrors.None;

                        return true;
                    };
                    System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                    client.Timeout = TimeSpan.FromMinutes(3);


                    client.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", Token);

                    ServicePointManager
                                .ServerCertificateValidationCallback +=
                                (sender, cert, chain, sslPolicyErrors) => true;
                    HttpResponseMessage responsePost = await client.GetAsync(GatewayEndpoint);

                    string s = await responsePost.Content.ReadAsStringAsync();

                    return s;
                }

            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally
            {
                //throttle.Take();
            }
        }


        public String CallGenericGetWithBasicAuthentication(RequestTypeAction RequestType, string GatewayEndpoint, String UserName, String Password)
            {
                if (String.IsNullOrEmpty(GatewayEndpoint))
                {
                    throw new Exception("Endpoint cannot be empty or null !");
                }

                return Task.Run(async () => await callGenericGetWithBasicAuthentication(RequestType, GatewayEndpoint, UserName, Password)).Result;
            }

            private static async Task<String> callGenericGetWithBasicAuthentication(RequestTypeAction RequestType, string GatewayEndpoint, String UserName, String Password)
            {
                try
                {
                    Uri uri = new Uri(GatewayEndpoint);
                    ServicePoint sp = ServicePointManager.FindServicePoint(uri);
                    sp.ConnectionLimit = 2;

                    var handler = new System.Net.Http.HttpClientHandler();
                    using (HttpClient client = new HttpClient(handler))
                    {
                        handler.ServerCertificateCustomValidationCallback = (request, cert, chain, errors) =>
                        {
                            // Log it, then use the same answer it would have had if we didn't make a callback.
                            Console.WriteLine(cert);
                            //return errors == SslPolicyErrors.None;

                            return true;
                        };
                        System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                        client.Timeout = TimeSpan.FromMinutes(3);


                        var dict = new Dictionary<string, string>();
                        dict.Add("username", UserName);
                        dict.Add("password", Password);
                        client.DefaultRequestHeaders.Authorization =
           new AuthenticationHeaderValue(
               "Basic", Convert.ToBase64String(
                   System.Text.ASCIIEncoding.ASCII.GetBytes(
                      $"{UserName}:{Password}")));
                        ServicePointManager
                                    .ServerCertificateValidationCallback +=
                                    (sender, cert, chain, sslPolicyErrors) => true;
                        HttpResponseMessage responsePost = await client.GetAsync(GatewayEndpoint);

                        string s = await responsePost.Content.ReadAsStringAsync();

                        return s;
                    }

                }
                catch (Exception ex)
                {
                    throw ex;

                }
                finally
                {
                    //throttle.Take();
                }
            }


        }
    }


