   services.AddControllers(options =>
            {
                var policy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();
                options.Filters.Add(new AuthorizeFilter(policy));
            });
            services.AddAuthentication(IISDefaults.AuthenticationScheme);
            services.AddAuthentication("BearerAuthentication")
                    .AddScheme<AuthenticationSchemeOptions, BearerAuthenticationHandler>("BearerAuthentication", null);
            services.AddCors();
            services.AddDependency(Configuration);
            services.AddAutoMapper(typeof(AutomapperProfile));
            ConfigureSwaggerService(services);
