# Love.Net.Help

A generate API documentation toolchain for ASP.NET Core.

# How to use

1. Install package

`PM> Install-Package Love.Net.Help`

2. Configure Services

Add API help to services `services.AddMvcCore()..AddApiHelp()`

```C#
        public void ConfigureServices(IServiceCollection services) {
            services.AddMvcCore()
                .AddJsonFormatters(options => {
                    options.ContractResolver = new DefaultContractResolver();
                }).AddApiHelp();

            services.UseDefaultAccountService<User>(null);
        }

```

3. Use *POSTMAN* to view the generated API

GET *http://yourdomain/api/help*

```JSON
    "POST api/Account/Register": {
      "Summary": "",
      "Request": {
        "model": {
          "Source": "Body",
          "Data": {
            "UserName": {
              "Summary": "用户名.",
              "Type": "String",
              "IsOptional": false
            },
            "Password": {
              "Summary": "密码.",
              "Type": "String",
              "IsOptional": false
            },
            "PhoneNumber": {
              "Summary": "电话号码.",
              "Type": "String",
              "IsOptional": false
            },
            "Code": {
              "Summary": "验证码.",
              "Type": "String",
              "IsOptional": false
            }
          },
          "Schema": {
            "UserName": "用户名.",
            "Password": "密码.",
            "PhoneNumber": "电话号码.",
            "Code": "验证码."
          }
        }
      },
      "Response": {
        "Data": {
          "AccessToken": {
            "Summary": "Gets the access token.",
            "Type": "String",
            "IsOptional": false
          },
          "ExpiresIn": {
            "Summary": "Gets the expires in.",
            "Type": "Int64",
            "IsOptional": false
          },
          "Raw": {
            "Summary": "Gets the raw.",
            "Type": "String",
            "IsOptional": false
          },
          "RefreshToken": {
            "Summary": "Gets the refresh token.",
            "Type": "String",
            "IsOptional": false
          },
          "TokenType": {
            "Summary": "Gets the type of the token.",
            "Type": "String",
            "IsOptional": false
          },
          "IsError": {
            "Summary": "Gets a value indicating whether this instance is error.",
            "Type": "Boolean",
            "IsOptional": false
          },
          "Error": {
            "Summary": "Gets the error.",
            "Type": "String",
            "IsOptional": false
          }
        },
        "Schema": {
          "AccessToken": "Gets the access token.",
          "ExpiresIn": 0,
          "Raw": "Gets the raw.",
          "RefreshToken": "Gets the refresh token.",
          "TokenType": "Gets the type of the token.",
          "IsError": false,
          "Error": "Gets the error."
        }
      }
    }
```

4. About UI

The currently impls doesn't include the UI, so if your team need an UI to improve the usage, you can use *angularjs* to do that, AND *wellcome to contribute* here. We will thank
your work.