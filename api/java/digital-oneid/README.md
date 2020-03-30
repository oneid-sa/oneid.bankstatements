# Spring Boot JWT

Spring Boot makes it easy to create Spring-powered, production-grade applications and services with absolute minimum fuss. It takes an opinionated view of the Spring platform so that new and existing users can quickly get to the bits they need.

You can use Spring Boot to create stand-alone Java applications that can be started using java -jar or more traditional WAR deployments.

# File structure

```
digital-oneid/
 │
 ├── src/main/java/digital
 │   └── oneid
 │       │
 │       ├── security
 │       │   ├── BCryptPasswordEncoder.java
 │       │   ├── JwtAuthenticationEntryPoint.java
 │       │   ├── JwtRequestFilter.java
 │       │   ├── JwtTokenUtil.java
 │       │   └── WebSecurityConfig.java
 │       │
 │       ├── controller
 │       │   └── JwtAuthenticationController.java
 │       │
 │       ├── repository
 │       │   ├── CertificateInfoRespository.java
 │       │   ├── JwtTokenRepository.java
 │       │   ├── CobrandRepository.java
 │       │   ├── UserRepository.java
 │       │   └── UserSessionRepository.java
 │       │
 │       ├── model
 │       │   ├── AccountResponse.java
 │       │   ├── AmountCurrency.java
 │       │   ├── CertificateTable.java
 │       │   ├── DAOUserRegistration.java
 │       │   ├── Dataset.java
 │       │   ├── ErrorResponse.java
 │       │   ├── GetAccountInfo.java
 │       │   ├── JwtRequest.java
 │       │   ├── JwtResponse.java
 │       │   ├── Statement.java
 │       │   ├── StatementResponse.java
 │       │   ├── YodleeJwtTokenInfo.java
 │       │   ├── TableCertificate.java
 │       │   ├── TableCobrandInfo.java
 │       │   ├── TableUserRegistration.java
 │       │   ├── TableYodleeJwtToken.java
 │       │   ├── Preference.java
 │       │   ├── Provider.java
 │       │   ├── FastlinkResponse.java
 │       │   └── ProviderResponse.java
 │       │
 │       ├── service
 │       │   └── JwtBusinessService.java
 │       │
 │       ├── utils
 │       │   ├── Constants.java
 │       │   ├── YodleeTokenGenerate.java
 │       │   └── YodleeServiceConsumer.java
 │       │
 │       └── JwtAuthServiceApp.java
 │
 ├── src/main/resources/
 │   ├── application.properties
 │   └── logback.xml
 │
 ├── .gitignore
 ├── LICENSE
 ├── mvnw/mvnw.cmd
 ├── README.md
 └── pom.xml
 ```

## Steps to build a project:

**Install Java**
> JDK 1.8 or later

**Install Maven**
> Maven 3.2+

**Compile Source Code**
> mvn clean compile

**Generate Jar**
> mvn clean -Dmaven.test.skip=true install