﻿using System;
using Canvas.v1.Auth;
using Canvas.v1.Config;
using Canvas.v1.Converter;
using Canvas.v1.Models;
using Canvas.v1.Request;
using Canvas.v1.Services;
using Moq;

namespace Canvas.v1.Test
{
    public abstract class ResourceManagerTest 
    {

        protected IJsonConverter _converter;
        protected Mock<IRequestHandler> _handler;
        protected IRequestService _service;
        protected Mock<ICanvasConfig> _config;
        protected AuthRepository _authRepository;

        protected Uri _baseUri = new Uri(Constants.ApiUriString);

        public ResourceManagerTest()
        {
            // Initial Setup
            _converter = new JsonConverter();
            _handler = new Mock<IRequestHandler>();
            _service = new RequestService(_handler.Object);
            _config = new Mock<ICanvasConfig>();

            _authRepository = new AuthRepository(_config.Object, _service, _converter, new OAuthSession("fakeAccessToken", "fakeRefreshToken", 3600, "bearer"));
        }
    }
}
