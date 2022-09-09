# Communicate between two WebApi projects using gRPC

There is quite a lot of article around gRPC off late. This repository will introduce you to gRPC, what it actually is, and how it compares to REST Protocol to get data from an ASP.NET Core WebApi using gRPC protocol.

##Here are the topics covered.
1. Introducing gRPC
2. REST vs gRPC
3. What are Protocol Buffers?
4. Streaming Request and Response
5. Avoiding conflict of WebApi and gRPC endpoints
6. Getting used to the gRPC Project Structure
7. Building a gRPC Service in an ASP.NET Core WebApi
8. Building gRPC Client in an ASP.NET Core WebApi

## Getting Started
If using Visual Studio just compile the solution and run two projects simultaneously using multiple startup projects. When two web api projects run go to StoreApi swagger page and try the controller endpoints. You will receive the data from ProductApi project using gRPC communication.
Using VS Code simply build and run two projects separately and then navigate to StoreApi swagger page and repeat the above.

## Give a Star! :star:

If you like or are using this project to learn, please give it a star. Thanks!

## Reporting Bugs and Asking Questions

Please use [Issues](https://github.com/shahabfar/gRPCSample/issues) to report actual bugs in the code. If you have questions, please ask them on twitter (mention [@shahabfar](https://twitter.com/shahabfar)).