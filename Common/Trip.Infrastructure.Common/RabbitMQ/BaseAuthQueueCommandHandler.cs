//using Microsoft.AspNetCore.Diagnostics;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Http.Features;
//using System;
//using System.Collections.Generic;
//using System.IdentityModel.Tokens.Jwt;
//using System.IO;
//using System.Linq;
//using System.Text;

//namespace AEG.Common.RabbitMQ
//{
//    public abstract class BaseAuthQueueCommandHandler : IQueueCommandHandler
//    {
//        protected IHttpContextAccessor _httpContextAccessor { get; set; }
//        public int AuthUserId { get; set; }
//        public string AuthUserName { get; set; }
//        private string AuthToken { get; set; }
//        public BaseAuthQueueCommandHandler()
//        {

//        }
//        public BaseAuthQueueCommandHandler(IHttpContextAccessor httpContextAccessor)
//        {
//            _httpContextAccessor = new HttpContextAccessor();
//        }
//        public void SetAuthAttributes(string authorizationHeaderToken)
//        {
//            if (_httpContextAccessor == null)
//                _httpContextAccessor = new HttpContextAccessor();

//            if (String.IsNullOrEmpty(authorizationHeaderToken))
//                throw new ArgumentNullException("AuthToken for Queue cannot be null");

//            AuthToken = authorizationHeaderToken.Split(" ")[1];

//            var tokenHandler = new JwtSecurityTokenHandler();
//            var paresedToken = tokenHandler.ReadJwtToken(AuthToken);
//            var identity = new System.Security.Claims.ClaimsIdentity(paresedToken.Claims);

//            IFeatureCollection features = new FeatureCollection();

//            //IExceptionHandlerFeature exceptionHandlerFeature = new ExceptionHandlerFeature { Error = new NotFoundException() };
//            //features.Set(exceptionHandlerFeature);
//            features.Set<IHttpRequestFeature>(new HttpRequestFeature());
//            features.Set<IHttpResponseFeature>(new HttpResponseFeature());
//            features.Set<IHttpResponseBodyFeature>(new StreamResponseBodyFeature(Stream.Null));

//            _httpContextAccessor.HttpContext = new DefaultHttpContext(features);
//            _httpContextAccessor.HttpContext.User = new System.Security.Claims.ClaimsPrincipal(identity);
//            _httpContextAccessor.HttpContext.Request.Headers.Add("Authorization", authorizationHeaderToken);

//            AuthUserId = Convert.ToInt32(identity.Claims.FirstOrDefault(c => c.Type == "UserId").Value);
//            AuthUserName = identity.Claims.FirstOrDefault(c => c.Type == "Name").Value;
//        }
//    }
//}
