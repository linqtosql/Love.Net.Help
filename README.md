# Love.Net.Help

A generate API documentation toolchain for ASP.NET Core.

[![Join the chat at https://gitter.im/lovedotnet/Love.Net.Help](https://badges.gitter.im/lovedotnet/Love.Net.Help.svg)](https://gitter.im/lovedotnet/Love.Net.Help?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge) 

# How to use

1. Install package

`PM> Install-Package Love.Net.Help`

2. Configure Services

Add API help to services `services.AddMvcCore().AddApiHelp()`

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

5. What's the different with others

There are many API help libaries, but I cann't found any library give the *Enum* define, and what's mean of the field. *Love.Net.Help* have this func

```C#
    public enum UserKind {
        /// <summary>
        /// From API
        /// </summary>
        FromApi,
        /// <summary>
        /// From web
        /// </summary>
        FromWeb,
        /// <summary>
        /// From test
        /// </summary>
        FromTest,
    }

    public class UserCreateModel {
        /// <summary>
        /// 用户名.
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 密码.
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 类型.
        /// </summary>
        public UserKind UserKind { get; set; }
    }
```

*Love.Net.Help* Will generate

```JSON
"POST api/Values": {
      "Summary": "",
      "Request": {
        "user": {
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
            "UserKind": {
              "Summary": {
                "0": "From API",
                "1": "From web",
                "2": "From test"
              },
              "Type": "Int32",
              "IsOptional": false
            }
          },
          "Schema": {
            "UserName": "用户名.",
            "Password": "密码.",
            "UserKind": 0
          }
        }
      },
      "Response": {
        "Data": {
          "Summary": {
            "0": "From API",
            "1": "From web",
            "2": "From test"
          },
          "Type": "Int32",
          "IsOptional": false
        },
        "Schema": 0
      }
    }
```