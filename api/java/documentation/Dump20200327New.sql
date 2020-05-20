CREATE DATABASE  IF NOT EXISTS `oneid` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `oneid`;
-- MySQL dump 10.13  Distrib 8.0.19, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: oneid
-- ------------------------------------------------------
-- Server version	8.0.19

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `action`
--

DROP TABLE IF EXISTS `action`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `action` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) DEFAULT NULL,
  `Description` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `action`
--

LOCK TABLES `action` WRITE;
/*!40000 ALTER TABLE `action` DISABLE KEYS */;
INSERT INTO `action` VALUES (1,'BankLogin',''),(2,'RetrieveStatement',''),(3,'TwoFactorAuthentication',''),(4,'Login',''),(5,'LogOut','');
/*!40000 ALTER TABLE `action` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `biometricposition`
--

DROP TABLE IF EXISTS `biometricposition`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `biometricposition` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(50) NOT NULL,
  `biometrictype_id` int NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `biometricposition`
--

LOCK TABLES `biometricposition` WRITE;
/*!40000 ALTER TABLE `biometricposition` DISABLE KEYS */;
INSERT INTO `biometricposition` VALUES (1,'LEFT_THUMB',1),(2,'LEFT_INDEX',1),(3,'LEFT_MIDDLE',1),(4,'LEFT_RING',1),(5,'LEFT_LITTLE',1),(6,'RIGHT_THUMB',1),(7,'RIGHT_INDEX',1),(8,'RIGHT_MIDDLE',1),(9,'RIGHT_RING',1),(10,'RIGHT_LITTLE',1),(11,'LEFT_EYE',3),(12,'RIGHT_EYE',3);
/*!40000 ALTER TABLE `biometricposition` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `biometrictype`
--

DROP TABLE IF EXISTS `biometrictype`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `biometrictype` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) NOT NULL,
  `Description` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `biometrictype`
--

LOCK TABLES `biometrictype` WRITE;
/*!40000 ALTER TABLE `biometrictype` DISABLE KEYS */;
INSERT INTO `biometrictype` VALUES (1,'Fingerprint',''),(2,'Face',''),(3,'Iris','');
/*!40000 ALTER TABLE `biometrictype` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `company`
--

DROP TABLE IF EXISTS `company`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `company` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) DEFAULT NULL,
  `RegistrationNumber` varchar(30) DEFAULT NULL,
  `VATNumber` varchar(45) DEFAULT NULL,
  `Address1` varchar(250) DEFAULT NULL,
  `Address2` varchar(250) DEFAULT NULL,
  `Address3` varchar(250) DEFAULT NULL,
  `Address4` varchar(250) DEFAULT NULL,
  `Address5` varchar(45) DEFAULT NULL,
  `ContactDetail_ID` varchar(45) DEFAULT NULL,
  `DateInserted` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `DateUpdated` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `company`
--

LOCK TABLES `company` WRITE;
/*!40000 ALTER TABLE `company` DISABLE KEYS */;
/*!40000 ALTER TABLE `company` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `company_user`
--

DROP TABLE IF EXISTS `company_user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `company_user` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `Company_ID` varchar(45) DEFAULT NULL,
  `User_ID` varchar(45) DEFAULT NULL,
  `Active` int DEFAULT NULL,
  `DateInserted` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `DateUpdated` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `company_user`
--

LOCK TABLES `company_user` WRITE;
/*!40000 ALTER TABLE `company_user` DISABLE KEYS */;
/*!40000 ALTER TABLE `company_user` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `enrolmentrequest`
--

DROP TABLE IF EXISTS `enrolmentrequest`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `enrolmentrequest` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(150) DEFAULT NULL,
  `Surname` varchar(150) DEFAULT NULL,
  `UniqueIdentifier` varchar(50) DEFAULT NULL,
  `MobileNumber` varchar(50) DEFAULT NULL,
  `EnrolmentReference` varchar(100) NOT NULL,
  `EnrolmentSourceReference` varchar(100) DEFAULT NULL,
  `EnrolmentSource_ID` int NOT NULL,
  `EnrolmentDevice_ID` varchar(50) NOT NULL,
  `DateInserted` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `DateUpdated` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `IMEI` varchar(50) DEFAULT NULL,
  `EnrolmentStatus_ID` int NOT NULL DEFAULT '1',
  `Gender` int DEFAULT NULL,
  `DateOfBirth` datetime DEFAULT NULL,
  `BirthPlace` varchar(150) DEFAULT NULL,
  `Nationality` varchar(3) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `enrolmentrequest`
--

LOCK TABLES `enrolmentrequest` WRITE;
/*!40000 ALTER TABLE `enrolmentrequest` DISABLE KEYS */;
/*!40000 ALTER TABLE `enrolmentrequest` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `enrolmentrequest_notificationmessage`
--

DROP TABLE IF EXISTS `enrolmentrequest_notificationmessage`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `enrolmentrequest_notificationmessage` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `EnrolmentRequest_ID` int NOT NULL,
  `NotificationMessage_ID` int NOT NULL,
  `DateInserted` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `DateUpdated` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `enrolmentrequest_notificationmessage`
--

LOCK TABLES `enrolmentrequest_notificationmessage` WRITE;
/*!40000 ALTER TABLE `enrolmentrequest_notificationmessage` DISABLE KEYS */;
/*!40000 ALTER TABLE `enrolmentrequest_notificationmessage` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `enrolmentsource`
--

DROP TABLE IF EXISTS `enrolmentsource`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `enrolmentsource` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) NOT NULL,
  `Description` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `enrolmentsource`
--

LOCK TABLES `enrolmentsource` WRITE;
/*!40000 ALTER TABLE `enrolmentsource` DISABLE KEYS */;
INSERT INTO `enrolmentsource` VALUES (1,'Tascent','');
/*!40000 ALTER TABLE `enrolmentsource` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `enrolmentstatus`
--

DROP TABLE IF EXISTS `enrolmentstatus`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `enrolmentstatus` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) NOT NULL,
  `Description` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `enrolmentstatus`
--

LOCK TABLES `enrolmentstatus` WRITE;
/*!40000 ALTER TABLE `enrolmentstatus` DISABLE KEYS */;
INSERT INTO `enrolmentstatus` VALUES (1,'ToBeSubmitted',''),(2,'Submitted',''),(3,'Enrolled',''),(4,'Duplicate',''),(5,'Unknown',''),(6,'ManualAdjudication',''),(7,'BadQuality','');
/*!40000 ALTER TABLE `enrolmentstatus` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `face`
--

DROP TABLE IF EXISTS `face`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `face` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `Image` longblob NOT NULL,
  `EnrolmentRequest_ID` int NOT NULL,
  `DateInserted` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `DateUpdated` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `face`
--

LOCK TABLES `face` WRITE;
/*!40000 ALTER TABLE `face` DISABLE KEYS */;
/*!40000 ALTER TABLE `face` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `fingerprint`
--

DROP TABLE IF EXISTS `fingerprint`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `fingerprint` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `Image` longblob NOT NULL,
  `BiometricPosition_ID` int NOT NULL,
  `EnrolmentRequest_ID` int NOT NULL,
  `DateInserted` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `DateUpdated` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `fingerprint`
--

LOCK TABLES `fingerprint` WRITE;
/*!40000 ALTER TABLE `fingerprint` DISABLE KEYS */;
/*!40000 ALTER TABLE `fingerprint` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `function`
--

DROP TABLE IF EXISTS `function`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `function` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) DEFAULT NULL,
  `Description` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `function`
--

LOCK TABLES `function` WRITE;
/*!40000 ALTER TABLE `function` DISABLE KEYS */;
INSERT INTO `function` VALUES (1,'UserManagement',''),(2,'BankLogin',''),(3,'BankStatement','');
/*!40000 ALTER TABLE `function` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `function_action_result_audit`
--

DROP TABLE IF EXISTS `function_action_result_audit`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `function_action_result_audit` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `Function_ID` int NOT NULL,
  `Action_ID` int NOT NULL,
  `FuctionActionResult_ID` int NOT NULL,
  `UniqueReference` varchar(100) NOT NULL,
  `DateTimeOfAction` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `Active` int NOT NULL DEFAULT '1',
  `AdditionalInfo` varchar(10000) DEFAULT NULL,
  `User_ID` int NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=99 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `function_action_result_audit`
--

LOCK TABLES `function_action_result_audit` WRITE;
/*!40000 ALTER TABLE `function_action_result_audit` DISABLE KEYS */;
INSERT INTO `function_action_result_audit` VALUES (1,2,1,2,'cc2f0887-d864-4b3a-b484-1512b323c140','2020-02-09 07:39:22',1,'',1),(2,2,2,2,'7279a07e-db7a-484e-94f0-55c4fbe455d1','2020-02-09 07:39:43',1,'',1),(3,2,1,3,'5d6905ba-7ff6-4906-a789-793ce697d7e2','2020-02-09 07:40:31',1,'System.Exception: Could not get a sucessfull response from the service provider. Response code is : 500, ResponseText is : Internal Server Error, Result Text is : [{\"Type\":\"error\",\"Code\":\"500\",\"Text\":\"Unable to login to Institution\"}]\r\n   at oneid.web.api.Controllers.BankStatements.BankLoginController.BankLogin(Object BankLoginValue) in C:\\Development\\OneID\\WebAPI\\oneid.web.api\\oneid.web.api\\oneid.web.api\\Controllers\\BankStatements\\BankLoginController.cs:line 317',1),(4,2,1,3,'360278ed-c9b8-4e8a-b83b-085f9dbe97cb','2020-02-09 07:44:10',1,'System.Exception: Could not get a sucessfull response from the service provider. Response code is : 500, ResponseText is : Internal Server Error, Result Text is : [{\"Type\":\"error\",\"Code\":\"500\",\"Text\":\"Unable to login to Institution\"}]\r\n   at oneid.web.api.Controllers.BankStatements.BankLoginController.BankLogin(Object BankLoginValue) in C:\\Development\\OneID\\WebAPI\\oneid.web.api\\oneid.web.api\\oneid.web.api\\Controllers\\BankStatements\\BankLoginController.cs:line 317',1),(5,2,1,3,'21950449-3257-435a-aba2-2dfa069f1484','2020-02-09 13:08:55',1,'System.Exception: Could not get a sucessfull response from the service provider. Response code is : 500, ResponseText is : Internal Server Error, Result Text is : [{\"Type\":\"error\",\"Code\":\"500\",\"Text\":\"Unable to login to Institution.\"}]\r\n   at oneid.web.api.Controllers.BankStatements.BankLoginController.BankLogin(Object BankLoginValue) in C:\\Development\\OneID\\WebAPI\\oneid.web.api\\oneid.web.api\\oneid.web.api\\Controllers\\BankStatements\\BankLoginController.cs:line 317',1),(6,2,1,2,'8f6ee9a5-76fd-40fe-a2bd-d2352624f04c','2020-02-10 15:32:12',1,'',1),(7,2,2,3,'00a58b2f-edde-4a0d-805d-87e27def1433','2020-02-10 15:32:28',1,'System.Exception: Response was not succesfull. Response details are, Code : 500, Reason : Internal Server Error, Result Text : [{\"Type\":\"error\",\"Code\":\"500\",\"Text\":\"Unable to fetch bank statement\"}]\r\n   at oneid.web.api.Controllers.BankStatements.RetrieveBankStatementsController.GetStatements(BankStatementRequest BankStatementRequestValue) in C:\\Development\\OneID\\WebAPI\\oneid.web.api\\oneid.web.api\\oneid.web.api\\Controllers\\BankStatements\\RetrieveBankStatementsController.cs:line 66',1),(8,2,2,3,'8831b96c-27aa-4166-9ac0-0dc9b4a5cf4c','2020-02-10 15:35:59',1,'System.Exception: Response was not succesfull. Response details are, Code : 500, Reason : Internal Server Error, Result Text : [{\"Type\":\"error\",\"Code\":\"500\",\"Text\":\"Failed to create connection\"}]\r\n   at oneid.web.api.Controllers.BankStatements.RetrieveBankStatementsController.GetStatements(BankStatementRequest BankStatementRequestValue) in C:\\Development\\OneID\\WebAPI\\oneid.web.api\\oneid.web.api\\oneid.web.api\\Controllers\\BankStatements\\RetrieveBankStatementsController.cs:line 66',1),(9,2,1,2,'47ab193a-c594-4f34-9338-6f7aba75fa31','2020-02-10 15:36:35',1,'',1),(10,2,2,3,'def0063f-3cf8-48f4-b53d-5c9fe93be084','2020-02-10 15:36:43',1,'System.Exception: Bankstatement is invalid !\r\n   at oneid.web.api.Controllers.BankStatements.RetrieveBankStatementsController.GetStatements(BankStatementRequest BankStatementRequestValue) in C:\\Development\\OneID\\WebAPI\\oneid.web.api\\oneid.web.api\\oneid.web.api\\Controllers\\BankStatements\\RetrieveBankStatementsController.cs:line 90',1),(11,2,1,2,'7c720328-e921-41fc-93b9-00ea29cb503f','2020-02-11 05:57:33',1,'',1),(12,2,2,2,'9befe02f-faba-46e0-838d-f245452b3448','2020-02-11 05:57:38',1,'',1),(13,2,1,2,'6112f196-6019-41bb-b358-b6087726f6d0','2020-02-11 05:59:15',1,'',1),(14,2,2,3,'a8de0494-e276-49a7-9e7c-36a43a47f358','2020-02-11 05:59:21',1,'System.Exception: Bankstatement is invalid !\r\n   at oneid.web.api.Controllers.BankStatements.RetrieveBankStatementsController.GetStatements(BankStatementRequest BankStatementRequestValue) in C:\\Development\\OneID\\WebAPI\\oneid.web.api\\oneid.web.api\\oneid.web.api\\Controllers\\BankStatements\\RetrieveBankStatementsController.cs:line 90',1),(15,2,2,3,'0ba4c1c4-a6d5-4911-adc7-33d7dcb6ebec','2020-02-11 05:59:33',1,'System.Exception: Bankstatement is invalid !\r\n   at oneid.web.api.Controllers.BankStatements.RetrieveBankStatementsController.GetStatements(BankStatementRequest BankStatementRequestValue) in C:\\Development\\OneID\\WebAPI\\oneid.web.api\\oneid.web.api\\oneid.web.api\\Controllers\\BankStatements\\RetrieveBankStatementsController.cs:line 90',1),(16,2,1,3,'7535f4c5-41d5-498a-a085-38255522df76','2020-02-11 07:25:13',1,'System.AggregateException: One or more errors occurred. (A task was canceled.)\r\n ---> System.Threading.Tasks.TaskCanceledException: A task was canceled.\r\n   --- End of inner exception stack trace ---\r\n   at System.Threading.Tasks.Task.ThrowIfExceptional(Boolean includeTaskCanceledExceptions)\r\n   at System.Threading.Tasks.Task`1.GetResultCore(Boolean waitCompletionNotification)\r\n   at System.Threading.Tasks.Task`1.get_Result()\r\n   at oneid.web.api.Services.RESTManager.CallGenericRestPostOAuth2Token[T](String RestFunction, String GatewayEndpoint, String JSONInput, Dictionary`2 HeaderDictionary, String Token) in C:\\Development\\OneID\\WebAPI\\oneid.web.api\\oneid.web.api\\oneid.web.api\\Services\\RESTManager.cs:line 74\r\n   at oneid.web.api.Controllers.BankStatements.BankLoginController.BankLogin(Object BankLoginValue) in C:\\Development\\OneID\\WebAPI\\oneid.web.api\\oneid.web.api\\oneid.web.api\\Controllers\\BankStatements\\BankLoginController.cs:line 251',1),(17,2,1,3,'35d7cf36-c1f9-49e8-a4bb-88c9112be7d2','2020-02-11 07:55:51',1,'System.AggregateException: One or more errors occurred. (A task was canceled.)\r\n ---> System.Threading.Tasks.TaskCanceledException: A task was canceled.\r\n   --- End of inner exception stack trace ---\r\n   at System.Threading.Tasks.Task.ThrowIfExceptional(Boolean includeTaskCanceledExceptions)\r\n   at System.Threading.Tasks.Task`1.GetResultCore(Boolean waitCompletionNotification)\r\n   at System.Threading.Tasks.Task`1.get_Result()\r\n   at oneid.web.api.Services.RESTManager.CallGenericRestPostOAuth2Token[T](String RestFunction, String GatewayEndpoint, String JSONInput, Dictionary`2 HeaderDictionary, String Token) in C:\\Development\\OneID\\WebAPI\\oneid.web.api\\oneid.web.api\\oneid.web.api\\Services\\RESTManager.cs:line 74\r\n   at oneid.web.api.Controllers.BankStatements.BankLoginController.BankLogin(Object BankLoginValue) in C:\\Development\\OneID\\WebAPI\\oneid.web.api\\oneid.web.api\\oneid.web.api\\Controllers\\BankStatements\\BankLoginController.cs:line 251',1),(18,2,1,2,'3040dca5-518d-45a9-962a-d89c360a38d3','2020-02-11 07:56:33',1,'',1),(19,2,2,2,'2decfdba-2f2f-4e68-89dc-d9c2512085a1','2020-02-11 07:56:43',1,'',1),(20,2,1,3,'64d7ca61-3f86-4c4d-bc38-ae64246dfdbd','2020-02-11 07:58:39',1,'System.Exception: Could not get a sucessfull response from the service provider. Response code is : 500, ResponseText is : Internal Server Error, Result Text is : [{\"Type\":\"error\",\"Code\":\"500\",\"Text\":\"Unable to login to Institution\"}]\r\n   at oneid.web.api.Controllers.BankStatements.BankLoginController.BankLogin(Object BankLoginValue) in C:\\Development\\OneID\\WebAPI\\oneid.web.api\\oneid.web.api\\oneid.web.api\\Controllers\\BankStatements\\BankLoginController.cs:line 317',1),(21,2,1,3,'6e64b5b9-bb13-49c6-8df8-6aa79e7b1419','2020-02-11 08:02:23',1,'System.Exception: Could not get a sucessfull response from the service provider. Response code is : 500, ResponseText is : Internal Server Error, Result Text is : [{\"Type\":\"error\",\"Code\":\"500\",\"Text\":\"Unable to login to Institution\"}]\r\n   at oneid.web.api.Controllers.BankStatements.BankLoginController.BankLogin(Object BankLoginValue) in C:\\Development\\OneID\\WebAPI\\oneid.web.api\\oneid.web.api\\oneid.web.api\\Controllers\\BankStatements\\BankLoginController.cs:line 317',1),(22,2,1,3,'0e829a43-c661-4233-b976-d8adcf017fab','2020-02-11 08:04:59',1,'System.Exception: Could not get a sucessfull response from the service provider. Response code is : 500, ResponseText is : Internal Server Error, Result Text is : [{\"Type\":\"error\",\"Code\":\"500\",\"Text\":\"Unable to login to Institution.\"}]\r\n   at oneid.web.api.Controllers.BankStatements.BankLoginController.BankLogin(Object BankLoginValue) in C:\\Development\\OneID\\WebAPI\\oneid.web.api\\oneid.web.api\\oneid.web.api\\Controllers\\BankStatements\\BankLoginController.cs:line 317',1),(23,2,1,3,'372f528a-f60e-4763-a09e-3873955bf3c8','2020-02-12 10:21:23',1,'System.Exception: Could not get a sucessfull response from the service provider. Response code is : 500, ResponseText is : Internal Server Error, Result Text is : [{\"Type\":\"error\",\"Code\":\"500\",\"Text\":\"Unable to login to Institution\"}]\r\n   at oneid.web.api.Controllers.BankStatements.BankLoginController.BankLogin(Object BankLoginValue) in C:\\Development\\OneID\\WebAPI\\oneid.web.api\\oneid.web.api\\oneid.web.api\\Controllers\\BankStatements\\BankLoginController.cs:line 317',1),(24,2,1,3,'fede9a14-e0a3-42b6-9a49-488109760669','2020-02-12 10:25:04',1,'System.Exception: Could not get a sucessfull response from the service provider. Response code is : 500, ResponseText is : Internal Server Error, Result Text is : [{\"Type\":\"error\",\"Code\":\"500\",\"Text\":\"Unable to login to Institution\"}]\r\n   at oneid.web.api.Controllers.BankStatements.BankLoginController.BankLogin(Object BankLoginValue) in C:\\Development\\OneID\\WebAPI\\oneid.web.api\\oneid.web.api\\oneid.web.api\\Controllers\\BankStatements\\BankLoginController.cs:line 317',1),(25,2,3,1,'ffe052f4-a1f7-49f7-a3ac-9549d03f9e4f','2020-02-12 10:26:26',1,'',1),(26,2,1,3,'ffe052f4-a1f7-49f7-a3ac-9549d03f9e4f','2020-02-12 10:26:27',1,'System.Exception: Could not get a sucessfull response from the service provider. Response code is : 500, ResponseText is : Internal Server Error, Result Text is : [{\"Type\":\"error\",\"Code\":\"500\",\"Text\":\"Object reference not set to an instance of an object.\"}]\r\n   at oneid.web.api.Controllers.BankStatements.BankLoginController.BankLogin(Object BankLoginValue) in C:\\Development\\OneID\\WebAPI\\oneid.web.api\\oneid.web.api\\oneid.web.api\\Controllers\\BankStatements\\BankLoginController.cs:line 317',1),(27,2,1,2,'4aab7378-53ba-4d89-b32a-9cf724929e32','2020-02-12 10:29:28',1,'',1),(28,2,2,2,'7948ca01-69ce-44e9-8509-7c51619a990d','2020-02-12 10:29:52',1,'',1),(29,2,1,2,'23788b04-7a8b-4d3e-b309-ccbd3acea610','2020-02-12 17:38:13',1,'',1),(30,2,2,3,'e7cee360-be22-4dbc-8ba4-816ebe1b3110','2020-02-12 17:38:23',1,'System.Exception: Bankstatement is invalid !\r\n   at oneid.web.api.Controllers.BankStatements.RetrieveBankStatementsController.GetStatements(BankStatementRequest BankStatementRequestValue) in C:\\Development\\OneID\\WebAPI\\oneid.web.api\\oneid.web.api\\oneid.web.api\\Controllers\\BankStatements\\RetrieveBankStatementsController.cs:line 90',1),(31,2,2,3,'cd2c9b02-4c75-4c1d-a3a5-e8342c32c09b','2020-02-12 17:38:35',1,'System.Exception: Bankstatement is invalid !\r\n   at oneid.web.api.Controllers.BankStatements.RetrieveBankStatementsController.GetStatements(BankStatementRequest BankStatementRequestValue) in C:\\Development\\OneID\\WebAPI\\oneid.web.api\\oneid.web.api\\oneid.web.api\\Controllers\\BankStatements\\RetrieveBankStatementsController.cs:line 90',1),(32,2,1,2,'e0759d65-623f-449b-a43d-4ad98876ac3e','2020-02-12 17:40:24',1,'',1),(33,2,2,3,'68ae6360-459d-48de-88ba-95bc9a13df83','2020-02-12 17:40:39',1,'System.Exception: Response was not succesfull. Response details are, Code : 500, Reason : Internal Server Error, Result Text : [{\"Type\":\"error\",\"Code\":\"500\",\"Text\":\"Unable to fetch bank statement\"}]\r\n   at oneid.web.api.Controllers.BankStatements.RetrieveBankStatementsController.GetStatements(BankStatementRequest BankStatementRequestValue) in C:\\Development\\OneID\\WebAPI\\oneid.web.api\\oneid.web.api\\oneid.web.api\\Controllers\\BankStatements\\RetrieveBankStatementsController.cs:line 66',1),(34,2,2,3,'f3385460-afb9-4204-aa85-5ee9f5f32763','2020-02-12 17:40:50',1,'System.Exception: Response was not succesfull. Response details are, Code : 500, Reason : Internal Server Error, Result Text : [{\"Type\":\"error\",\"Code\":\"500\",\"Text\":\"Unable to fetch bank statement\"}]\r\n   at oneid.web.api.Controllers.BankStatements.RetrieveBankStatementsController.GetStatements(BankStatementRequest BankStatementRequestValue) in C:\\Development\\OneID\\WebAPI\\oneid.web.api\\oneid.web.api\\oneid.web.api\\Controllers\\BankStatements\\RetrieveBankStatementsController.cs:line 66',1),(35,2,1,2,'8327866d-72da-46aa-8c2d-50becc07d0d6','2020-02-12 18:20:05',1,'',1),(36,2,3,2,'14b5e3f3-44b8-43f0-b72b-e284b4255952','2020-02-12 18:57:38',1,'',1),(37,2,1,2,'5dd61d32-2a46-411d-b149-ebc8d1172c15','2020-02-12 19:11:54',1,'',1),(38,2,2,3,'27645886-ff9c-4130-8e09-a6883318504c','2020-02-12 19:12:04',1,'System.Exception: Response was not succesfull. Response details are, Code : 500, Reason : Internal Server Error, Result Text : [{\"Type\":\"error\",\"Code\":\"500\",\"Text\":\"Unable to fetch bank statement\"}]\r\n   at oneid.web.api.Controllers.BankStatements.RetrieveBankStatementsController.GetStatements(BankStatementRequest BankStatementRequestValue) in C:\\Development\\OneID\\WebAPI\\oneid.web.api\\oneid.web.api\\oneid.web.api\\Controllers\\BankStatements\\RetrieveBankStatementsController.cs:line 71',1),(39,2,1,2,'230fd5ea-9c83-4130-bdaf-ed65d768e8a1','2020-02-12 19:16:14',1,'',1),(40,2,2,3,'1cd5dfd9-08d3-424c-8d1d-9badca854b3d','2020-02-12 19:18:07',1,'System.Exception: Bankstatement is invalid !\r\n   at oneid.web.api.Controllers.BankStatements.RetrieveBankStatementsController.GetStatements(BankStatementRequest BankStatementRequestValue) in C:\\Development\\OneID\\WebAPI\\oneid.web.api\\oneid.web.api\\oneid.web.api\\Controllers\\BankStatements\\RetrieveBankStatementsController.cs:line 93',1),(41,2,1,2,'f64eb948-0feb-4dd0-8585-8866344712b5','2020-02-12 19:29:51',1,'',1),(42,2,1,2,'21b976a0-4079-418c-9839-11f0de27fb6a','2020-02-14 08:42:40',1,'',1),(43,2,2,2,'7e8fffb9-9a86-4fbb-a9c4-fd88bd9aa8fa','2020-02-14 08:42:51',1,'',1),(44,2,1,2,'b7953190-090c-46fb-aaaa-0f97b8efd385','2020-02-14 08:43:50',1,'',1),(45,2,2,2,'fa02db0d-bcc9-44ed-9264-6e0e596a6ac7','2020-02-14 08:44:05',1,'',1),(46,2,1,2,'c21b224f-efae-4ce1-8784-ce83f27c32d1','2020-02-14 08:45:41',1,'',1),(47,2,2,3,'95f430dc-333e-4ded-80cf-d4d1fe696662','2020-02-14 08:45:51',1,'System.Exception: Response was not succesfull. Response details are, Code : 500, Reason : Internal Server Error, Result Text : [{\"Type\":\"error\",\"Code\":\"500\",\"Text\":\"Unable to fetch bank statement\"}]\r\n   at oneid.web.api.Controllers.BankStatements.RetrieveBankStatementsController.GetStatements(BankStatementRequest BankStatementRequestValue) in C:\\Development\\OneID\\WebAPI\\oneid.web.api\\oneid.web.api\\oneid.web.api\\Controllers\\BankStatements\\RetrieveBankStatementsController.cs:line 71',1),(48,2,2,3,'b4600493-051c-4dfb-874a-dd7fce77dbdc','2020-02-14 08:46:05',1,'System.Exception: Response was not succesfull. Response details are, Code : 500, Reason : Internal Server Error, Result Text : [{\"Type\":\"error\",\"Code\":\"500\",\"Text\":\"Unable to fetch bank statement\"}]\r\n   at oneid.web.api.Controllers.BankStatements.RetrieveBankStatementsController.GetStatements(BankStatementRequest BankStatementRequestValue) in C:\\Development\\OneID\\WebAPI\\oneid.web.api\\oneid.web.api\\oneid.web.api\\Controllers\\BankStatements\\RetrieveBankStatementsController.cs:line 71',1),(49,2,1,2,'a5c11475-8129-4660-877f-b17163e5c507','2020-02-16 18:06:19',1,'',1),(50,2,2,2,'8b4b7e9b-7f56-4376-8383-5136c07f4c53','2020-02-16 18:06:34',1,'',1),(51,2,1,3,'ed8c4677-40e9-48b7-83e8-2e7e9ba15e62','2020-02-17 07:47:10',1,'System.Exception: Could not get a sucessfull response from the service provider. Response code is : 500, ResponseText is : Internal Server Error, Result Text is : [{\"Type\":\"error\",\"Code\":\"500\",\"Text\":\"Unable to login to Institution\"}]\r\n   at oneid.web.api.Controllers.BankStatements.BankLoginController.BankLogin(Object BankLoginValue) in C:\\Development\\OneID\\WebAPI\\oneid.web.api\\oneid.web.api\\oneid.web.api\\Controllers\\BankStatements\\BankLoginController.cs:line 320',1),(52,2,1,3,'e17fbca5-5d1f-41e6-b88c-13598e98c3fc','2020-02-17 07:49:00',1,'System.Exception: Could not get a sucessfull response from the service provider. Response code is : 500, ResponseText is : Internal Server Error, Result Text is : [{\"Type\":\"error\",\"Code\":\"500\",\"Text\":\"Unable to login to Institution\"}]\r\n   at oneid.web.api.Controllers.BankStatements.BankLoginController.BankLogin(Object BankLoginValue) in C:\\Development\\OneID\\WebAPI\\oneid.web.api\\oneid.web.api\\oneid.web.api\\Controllers\\BankStatements\\BankLoginController.cs:line 320',1),(53,2,1,2,'95eac19a-04d6-4335-aefb-618cf8700f3c','2020-02-17 07:50:09',1,'',1),(54,2,2,3,'c517fd3f-dda2-4377-b707-03a71d596c8f','2020-02-17 07:50:30',1,'System.Exception: Response was not succesfull. Response details are, Code : 400, Reason : Bad Request, Result Text : [{\"type\":\"error\",\"code\":\"400\",\"text\":\"accountId - Error converting value \\\"\\\" to type \'System.Guid\'. Path \'accountId\', line 1, position 66.\"}]\r\n   at oneid.web.api.Controllers.BankStatements.RetrieveBankStatementsController.GetStatements(BankStatementRequest BankStatementRequestValue) in C:\\Development\\OneID\\WebAPI\\oneid.web.api\\oneid.web.api\\oneid.web.api\\Controllers\\BankStatements\\RetrieveBankStatementsController.cs:line 71',1),(55,2,1,2,'fbe7e217-06e8-44d4-9864-8be4ef91e348','2020-02-17 07:53:35',1,'',1),(56,2,2,2,'34dfef59-4104-4353-add9-addd2b2b0d15','2020-02-17 07:53:58',1,'',1),(57,2,1,2,'b0cd0e05-27dd-4d9c-9fee-675f09893438','2020-02-21 12:53:31',1,'',1),(58,2,2,2,'57cb6b95-1135-4211-8a62-8ad2da069f10','2020-02-21 12:53:49',1,'',1),(59,2,1,2,'06045868-270a-4dfa-81fc-3bd12b801f4b','2020-02-21 12:55:15',1,'',1),(60,2,2,2,'e719aa1d-283d-4efd-b1bb-f4331cc7da0a','2020-02-21 12:57:30',1,'',1),(61,2,1,3,'1ec4b4a0-0452-418e-85ac-c0f9112339e7','2020-02-21 12:58:57',1,'System.Exception: Could not get a sucessfull response from the service provider. Response code is : 500, ResponseText is : Internal Server Error, Result Text is : [{\"Type\":\"error\",\"Code\":\"500\",\"Text\":\"Unable to login to Institution\"}]\r\n   at oneid.web.api.Controllers.BankStatements.BankLoginController.BankLogin(Object BankLoginValue) in C:\\Development\\OneID\\WebAPI\\oneid.web.api\\oneid.web.api\\oneid.web.api\\Controllers\\BankStatements\\BankLoginController.cs:line 320',1),(62,2,1,2,'b7db262c-b927-477c-94f6-e53ac4eba627','2020-02-21 13:01:10',1,'',1),(63,2,1,2,'6cb3c766-62d1-4e69-b200-fe84e0dd5101','2020-02-21 13:01:58',1,'',1),(64,2,1,2,'e9f607cb-fec8-40e4-8e69-b1a8c784a606','2020-02-21 13:03:00',1,'',1),(65,2,1,2,'122f4e69-56e4-4507-833b-b84e3b15ea3d','2020-02-23 10:16:06',1,'',1),(66,2,2,2,'cd6a65a5-21b4-46a0-8c33-94b0e3d96245','2020-02-23 10:16:19',1,'',1),(67,2,2,2,'19ee7631-101d-43f3-8b42-180a9295f142','2020-02-23 10:19:20',1,'',1),(68,2,1,3,'af71ead5-5cde-4fc3-8931-604fdfded6c7','2020-02-23 10:23:38',1,'System.Exception: Could not get a sucessfull response from the service provider. Response code is : 500, ResponseText is : Internal Server Error, Result Text is : [{\"Type\":\"error\",\"Code\":\"500\",\"Text\":\"Unable to login to Institution\"}]\r\n   at oneid.web.api.Controllers.BankStatements.BankLoginController.BankLogin(Object BankLoginValue) in C:\\Development\\OneID\\WebAPI\\oneid.web.api\\oneid.web.api\\oneid.web.api\\Controllers\\BankStatements\\BankLoginController.cs:line 320',1),(69,2,1,2,'cc7d1cf6-c136-4192-851a-6f102d0aa229','2020-02-23 10:49:19',1,'',1),(70,2,2,3,'ecb60d2c-5484-4102-996f-0e4b832b83c8','2020-02-23 10:50:32',1,'System.Exception: Response was not succesfull. Response details are, Code : 500, Reason : Internal Server Error, Result Text : [{\"Type\":\"error\",\"Code\":\"500\",\"Text\":\"Unable to fetch bank statement\"}]\r\n   at oneid.web.api.Controllers.BankStatements.RetrieveBankStatementsController.GetStatements(BankStatementRequest BankStatementRequestValue) in C:\\Development\\OneID\\WebAPI\\oneid.web.api\\oneid.web.api\\oneid.web.api\\Controllers\\BankStatements\\RetrieveBankStatementsController.cs:line 71',1),(71,2,2,3,'88d43e9d-b397-4955-866a-245fb95b7eb7','2020-02-23 10:53:23',1,'System.Exception: Bankstatement is invalid !\r\n   at oneid.web.api.Controllers.BankStatements.RetrieveBankStatementsController.GetStatements(BankStatementRequest BankStatementRequestValue) in C:\\Development\\OneID\\WebAPI\\oneid.web.api\\oneid.web.api\\oneid.web.api\\Controllers\\BankStatements\\RetrieveBankStatementsController.cs:line 93',1),(72,2,1,2,'5b1edab7-f563-4b92-a699-acdb9d49d964','2020-02-23 10:59:04',1,'',1),(73,2,2,2,'e48e37e3-be5b-4c7c-92db-b85c0a294823','2020-02-23 10:59:16',1,'',1),(74,2,1,2,'57d2bb8d-5acf-45be-87be-3465154126ac','2020-02-23 11:00:12',1,'',1),(75,2,2,2,'b261b79b-5dda-466b-895d-ee2fb37399ad','2020-02-23 11:00:26',1,'',1),(76,2,2,3,'d279688b-6dc9-47c5-92c4-87803a35d891','2020-02-23 11:00:37',1,'System.Exception: Response was not succesfull. Response details are, Code : 500, Reason : Internal Server Error, Result Text : [{\"Type\":\"error\",\"Code\":\"500\",\"Text\":\"Unable to fetch bank statement\"}]\r\n   at oneid.web.api.Controllers.BankStatements.RetrieveBankStatementsController.GetStatements(BankStatementRequest BankStatementRequestValue) in C:\\Development\\OneID\\WebAPI\\oneid.web.api\\oneid.web.api\\oneid.web.api\\Controllers\\BankStatements\\RetrieveBankStatementsController.cs:line 71',1),(77,2,1,2,'6a51bb03-ed5a-46a3-ae2e-8711a6553ea1','2020-02-23 11:00:49',1,'',1),(78,2,2,2,'4c16d58e-71b3-4a41-bcdc-8abd28f26c12','2020-02-23 11:01:04',1,'',1),(79,2,1,3,'39542fc2-9665-45eb-ba72-ea6a5c9f8224','2020-02-24 07:38:46',1,'System.Exception: Could not get a sucessfull response from the service provider. Response code is : 500, ResponseText is : Internal Server Error, Result Text is : [{\"Type\":\"error\",\"Code\":\"500\",\"Text\":\"Unable to login to Institution\"}]\r\n   at oneid.web.api.Controllers.BankStatements.BankLoginController.BankLogin(Object BankLoginValue) in C:\\Development\\OneID\\WebAPI\\oneid.web.api\\oneid.web.api\\oneid.web.api\\Controllers\\BankStatements\\BankLoginController.cs:line 320',1),(80,2,1,3,'a5221d18-cd7b-4bd4-88e5-5fb6d907c680','2020-02-24 10:16:36',1,'System.Exception: Could not get a sucessfull response from the service provider. Response code is : 500, ResponseText is : Internal Server Error, Result Text is : [{\"Type\":\"error\",\"Code\":\"500\",\"Text\":\"Unable to login to Institution\"}]\r\n   at oneid.web.api.Controllers.BankStatements.BankLoginController.BankLogin(Object BankLoginValue) in C:\\Development\\OneID\\WebAPI\\oneid.web.api\\oneid.web.api\\oneid.web.api\\Controllers\\BankStatements\\BankLoginController.cs:line 320',1),(81,2,1,3,'bd1ce8f6-45c3-4bea-a578-f85d9130b740','2020-02-24 10:49:53',1,'System.Exception: Could not get a sucessfull response from the service provider. Response code is : 500, ResponseText is : Internal Server Error, Result Text is : [{\"Type\":\"error\",\"Code\":\"500\",\"Text\":\"Unable to login to Institution\"}]\r\n   at oneid.web.api.Controllers.BankStatements.BankLoginController.BankLogin(Object BankLoginValue) in C:\\Development\\OneID\\WebAPI\\oneid.web.api\\oneid.web.api\\oneid.web.api\\Controllers\\BankStatements\\BankLoginController.cs:line 320',1),(82,2,1,3,'db98571b-847c-44d5-ad4f-c4c6e9e305de','2020-02-24 13:30:39',1,'System.Exception: Could not get a sucessfull response from the service provider. Response code is : 500, ResponseText is : Internal Server Error, Result Text is : [{\"Type\":\"error\",\"Code\":\"500\",\"Text\":\"Unable to login to Institution\"}]\r\n   at oneid.web.api.Controllers.BankStatements.BankLoginController.BankLogin(Object BankLoginValue) in C:\\Development\\OneID\\WebAPI\\oneid.web.api\\oneid.web.api\\oneid.web.api\\Controllers\\BankStatements\\BankLoginController.cs:line 320',1),(83,2,1,3,'c22da8c5-18e9-4de3-86e1-607cffc3d4f2','2020-02-24 18:27:35',1,'System.Exception: Could not get a sucessfull response from the service provider. Response code is : 500, ResponseText is : Internal Server Error, Result Text is : [{\"Type\":\"error\",\"Code\":\"500\",\"Text\":\"Unable to login to Institution\"}]\r\n   at oneid.web.api.Controllers.BankStatements.BankLoginController.BankLogin(Object BankLoginValue) in C:\\Development\\OneID\\WebAPI\\oneid.web.api\\oneid.web.api\\oneid.web.api\\Controllers\\BankStatements\\BankLoginController.cs:line 320',1),(84,2,1,3,'5bd1a069-9a75-4935-8269-240aff560bde','2020-02-25 08:16:22',1,'System.Exception: Could not get a sucessfull response from the service provider. Response code is : 500, ResponseText is : Internal Server Error, Result Text is : [{\"Type\":\"error\",\"Code\":\"500\",\"Text\":\"Unable to login to Institution\"}]\r\n   at oneid.web.api.Controllers.BankStatements.BankLoginController.BankLogin(Object BankLoginValue) in C:\\Development\\OneID\\WebAPI\\oneid.web.api\\oneid.web.api\\oneid.web.api\\Controllers\\BankStatements\\BankLoginController.cs:line 320',1),(85,2,1,3,'1fa87aeb-c298-46f8-94fe-deed38965ab0','2020-02-26 08:57:31',1,'System.Exception: Could not get a sucessfull response from the service provider. Response code is : 500, ResponseText is : Internal Server Error, Result Text is : [{\"Type\":\"error\",\"Code\":\"500\",\"Text\":\"Unable to login to Institution\"}]\r\n   at oneid.web.api.Controllers.BankStatements.BankLoginController.BankLogin(Object BankLoginValue) in C:\\Development\\OneID\\WebAPI\\oneid.web.api\\oneid.web.api\\oneid.web.api\\Controllers\\BankStatements\\BankLoginController.cs:line 320',1),(86,2,1,2,'1eb2f6c0-90fa-4412-aa2b-b6e415479999','2020-02-28 06:51:09',1,'',1),(87,2,2,3,'778cdf28-f129-43c4-8257-f05e404f7fa8','2020-02-28 06:52:04',1,'System.Exception: Response was not succesfull. Response details are, Code : 500, Reason : Internal Server Error, Result Text : [{\"Type\":\"error\",\"Code\":\"500\",\"Text\":\"Unable to fetch bank statement\"}]\r\n   at oneid.web.api.Controllers.BankStatements.RetrieveBankStatementsController.GetStatements(BankStatementRequest BankStatementRequestValue) in C:\\Development\\OneID\\WebAPI\\oneid.web.api\\oneid.web.api\\oneid.web.api\\Controllers\\BankStatements\\RetrieveBankStatementsController.cs:line 71',1),(88,2,1,2,'0e906d55-1a4f-46e7-a525-5cd3039b8c69','2020-03-01 15:40:10',1,'',1),(89,2,2,3,'94d79173-bc21-47ce-b9b5-83cdbe3cd631','2020-03-01 15:42:03',1,'System.Exception: Response was not succesfull. Response details are, Code : 500, Reason : Internal Server Error, Result Text : [{\"Type\":\"error\",\"Code\":\"500\",\"Text\":\"Unable to fetch bank statement\"}]\r\n   at oneid.web.api.Controllers.BankStatements.RetrieveBankStatementsController.GetStatements(BankStatementRequest BankStatementRequestValue) in C:\\Development\\OneID\\WebAPI\\oneid.web.api\\oneid.web.api\\oneid.web.api\\Controllers\\BankStatements\\RetrieveBankStatementsController.cs:line 71',1),(90,2,1,2,'3d48cd70-0ac7-45b3-bfa4-8fc40a48a10e','2020-03-02 13:09:19',1,'',1),(91,2,2,3,'cf0991b2-0fbf-4668-b788-8be9cfeb3cca','2020-03-02 13:10:16',1,'System.Exception: Response was not succesfull. Response details are, Code : 500, Reason : Internal Server Error, Result Text : [{\"Type\":\"error\",\"Code\":\"500\",\"Text\":\"Unable to fetch bank statement\"}]\r\n   at oneid.web.api.Controllers.BankStatements.RetrieveBankStatementsController.GetStatements(BankStatementRequest BankStatementRequestValue) in C:\\Development\\OneID\\WebAPI\\oneid.web.api\\oneid.web.api\\oneid.web.api\\Controllers\\BankStatements\\RetrieveBankStatementsController.cs:line 71',1),(92,2,2,3,'fd3cf07c-a924-4d66-9c52-06ffd0c28266','2020-03-02 13:11:58',1,'System.Exception: Response was not succesfull. Response details are, Code : 500, Reason : Internal Server Error, Result Text : [{\"Type\":\"error\",\"Code\":\"500\",\"Text\":\"Unable to fetch bank statement\"}]\r\n   at oneid.web.api.Controllers.BankStatements.RetrieveBankStatementsController.GetStatements(BankStatementRequest BankStatementRequestValue) in C:\\Development\\OneID\\WebAPI\\oneid.web.api\\oneid.web.api\\oneid.web.api\\Controllers\\BankStatements\\RetrieveBankStatementsController.cs:line 71',1),(93,2,1,2,'ffa51532-9d75-4532-b0e4-23b47730e72f','2020-03-03 09:05:50',1,'',1),(94,2,2,2,'3a052f9c-0df3-412e-b0fe-924697fe74c8','2020-03-03 09:06:20',1,'',1),(95,2,1,2,'118d7d30-b7f8-4318-9da1-2787f8c8b606','2020-03-03 09:08:06',1,'',1),(96,2,2,3,'ba9dcc4e-8438-4fa5-bdcb-ded506661107','2020-03-03 09:08:16',1,'System.Exception: Response was not succesfull. Response details are, Code : 500, Reason : Internal Server Error, Result Text : [{\"Type\":\"error\",\"Code\":\"500\",\"Text\":\"Unable to fetch bank statement\"}]\r\n   at oneid.web.api.Controllers.BankStatements.RetrieveBankStatementsController.GetStatements(BankStatementRequest BankStatementRequestValue) in C:\\Development\\OneID\\WebAPI\\oneid.web.api\\oneid.web.api\\oneid.web.api\\Controllers\\BankStatements\\RetrieveBankStatementsController.cs:line 71',1),(97,2,1,2,'52937457-4bb9-4181-a7bb-64cae4925bae','2020-03-13 08:59:33',1,'',1),(98,2,2,3,'5d0650cf-9752-47ae-bc9f-57f0d668f5c7','2020-03-13 09:00:21',1,'System.Exception: Response was not succesfull. Response details are, Code : 500, Reason : Internal Server Error, Result Text : [{\"Type\":\"error\",\"Code\":\"500\",\"Text\":\"Unable to fetch bank statement for account\"}]\r\n   at oneid.web.api.Controllers.BankStatements.RetrieveBankStatementsController.GetStatements(BankStatementRequest BankStatementRequestValue) in C:\\Development\\OneID\\WebAPI\\oneid.web.api\\oneid.web.api\\oneid.web.api\\Controllers\\BankStatements\\RetrieveBankStatementsController.cs:line 71',1);
/*!40000 ALTER TABLE `function_action_result_audit` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `function_action_result_audit_additionaltag`
--

DROP TABLE IF EXISTS `function_action_result_audit_additionaltag`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `function_action_result_audit_additionaltag` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `function_action_result_audit_id` int DEFAULT NULL,
  `TagName_id` int DEFAULT NULL,
  `TagValue` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=104 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `function_action_result_audit_additionaltag`
--

LOCK TABLES `function_action_result_audit_additionaltag` WRITE;
/*!40000 ALTER TABLE `function_action_result_audit_additionaltag` DISABLE KEYS */;
INSERT INTO `function_action_result_audit_additionaltag` VALUES (1,1,0,'Nedbank'),(2,1,0,NULL),(3,3,0,'ABSA'),(4,3,0,NULL),(5,4,0,'ABSA'),(6,4,0,NULL),(7,5,0,'StandardBank'),(8,5,0,NULL),(9,6,0,'Nedbank'),(10,6,0,NULL),(11,9,0,'Nedbank'),(12,9,0,NULL),(13,11,0,'Capitec'),(14,11,0,NULL),(15,13,0,'Nedbank'),(16,13,0,NULL),(17,18,0,'Capitec'),(18,18,0,NULL),(19,20,0,'FNB'),(20,20,0,NULL),(21,21,0,'ABSA'),(22,21,0,NULL),(23,22,0,'StandardBank'),(24,22,0,NULL),(25,23,0,'ABSA'),(26,23,0,NULL),(27,24,0,'FNB'),(28,24,0,NULL),(29,25,0,'StandardBank'),(30,25,0,NULL),(31,26,0,'StandardBank'),(32,26,0,NULL),(33,27,0,'Capitec'),(34,27,0,NULL),(35,29,0,'Nedbank'),(36,29,0,NULL),(37,32,0,'Nedbank'),(38,32,0,NULL),(39,35,0,'Capitec'),(40,35,0,NULL),(41,37,0,'Nedbank'),(42,37,0,NULL),(43,39,0,'StandardBank'),(44,39,0,NULL),(45,40,0,'f7a7c01e-c5d4-4fb1-8e83-da365377d802'),(46,41,0,'StandardBank'),(47,41,0,'993f2db4-f8b3-4fd4-ae79-9f1aea8432d3'),(48,42,0,'Nedbank'),(49,42,0,'33c8a245-4bd1-43f8-935d-a5cd3247bef6'),(50,44,0,'Nedbank'),(51,44,0,'74506d0e-e0b7-49a3-b58e-ba27c5243475'),(52,46,0,'Nedbank'),(53,46,0,'dfa7a92f-b4ee-4c8f-8fb5-c0670d9d2b9a'),(54,47,0,'dfa7a92f-b4ee-4c8f-8fb5-c0670d9d2b9a'),(55,48,0,'dfa7a92f-b4ee-4c8f-8fb5-c0670d9d2b9a'),(56,49,0,'Capitec'),(57,49,0,'1957448a-0115-49c4-a3be-1bec9f4f44d6'),(58,53,0,'StandardBank'),(59,53,0,'401e7105-f937-4eb6-a799-52f0179eaa90'),(60,54,0,'401e7105-f937-4eb6-a799-52f0179eaa90'),(61,55,0,'Capitec'),(62,55,0,'9b4a49fb-19a5-4078-b251-2da20e9c2a36'),(63,57,0,'Capitec'),(64,57,0,'de825e68-dac7-415d-a9ce-3d2c7ee4c3e9'),(65,59,0,'ABSA'),(66,59,0,'c772afcb-f36b-4285-b4ea-bda403307e13'),(67,62,0,'StandardBank'),(68,62,0,'3ac82e2c-cb0b-419b-a139-0894cc0157fd'),(69,63,0,'StandardBank'),(70,63,0,'68383735-7439-4929-b837-33b3dce95c04'),(71,64,0,'StandardBank'),(72,64,0,'14d87aed-fff5-4fa5-96fd-e5ef8e2ff2d5'),(73,65,0,'ABSA'),(74,65,0,'5edb671c-5029-46af-940c-77e147ae7c94'),(75,69,0,'Nedbank'),(76,69,0,'228a1db3-f8d0-42ca-965e-8eac28eda72c'),(77,70,0,'228a1db3-f8d0-42ca-965e-8eac28eda72c'),(78,71,0,'228a1db3-f8d0-42ca-965e-8eac28eda72c'),(79,72,0,'Nedbank'),(80,72,0,'ffc91db9-06a0-4684-a7b6-338c05edcbca'),(81,74,0,'Nedbank'),(82,74,0,'35d6248b-22cf-46a0-acca-4fe402414836'),(83,76,0,'35d6248b-22cf-46a0-acca-4fe402414836'),(84,77,0,'Nedbank'),(85,77,0,'4904822e-f56b-4c56-8fe3-27759ad5acd3'),(86,86,0,'FNB'),(87,86,0,'a61430e0-9d61-409f-b616-48b3f668ecd2'),(88,87,0,'a61430e0-9d61-409f-b616-48b3f668ecd2'),(89,88,0,'FNB'),(90,88,0,'60ffb32b-eed3-4239-b19b-708bb745c911'),(91,89,0,'60ffb32b-eed3-4239-b19b-708bb745c911'),(92,90,0,'FNB'),(93,90,0,'73ddd0c4-1493-43a2-a99e-0d1af6303be0'),(94,91,0,'73ddd0c4-1493-43a2-a99e-0d1af6303be0'),(95,92,0,'73ddd0c4-1493-43a2-a99e-0d1af6303be0'),(96,93,0,'FNB'),(97,93,0,'c768e2a2-accd-4d6f-ada1-611a0ed0eda0'),(98,95,0,'FNB'),(99,95,0,'1ca745e0-f7db-4fba-a913-22f1970e3181'),(100,96,0,'1ca745e0-f7db-4fba-a913-22f1970e3181'),(101,97,0,'ABSA'),(102,97,0,'c26b7697-a7b0-4e5a-861b-6ba75ee1ca6d'),(103,98,0,'c26b7697-a7b0-4e5a-861b-6ba75ee1ca6d');
/*!40000 ALTER TABLE `function_action_result_audit_additionaltag` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `functionactionresult`
--

DROP TABLE IF EXISTS `functionactionresult`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `functionactionresult` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) DEFAULT NULL,
  `Description` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='			';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `functionactionresult`
--

LOCK TABLES `functionactionresult` WRITE;
/*!40000 ALTER TABLE `functionactionresult` DISABLE KEYS */;
/*!40000 ALTER TABLE `functionactionresult` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `hanissearchrequest`
--

DROP TABLE IF EXISTS `hanissearchrequest`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `hanissearchrequest` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `IDNumber` varchar(50) NOT NULL,
  `Name` varchar(200) DEFAULT NULL,
  `Surname` varchar(200) DEFAULT NULL,
  `Photo` longblob,
  `TransactionReference` varchar(100) NOT NULL,
  `OnHANIS` bit(1) DEFAULT NULL,
  `OnNPR` bit(1) DEFAULT NULL,
  `DHAError` varchar(10000) DEFAULT NULL,
  `IDNumberBlocked` bit(1) DEFAULT NULL,
  `HANISSearchStatus_ID` int NOT NULL,
  `DateInserted` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `DateUpdated` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `hanissearchrequest`
--

LOCK TABLES `hanissearchrequest` WRITE;
/*!40000 ALTER TABLE `hanissearchrequest` DISABLE KEYS */;
/*!40000 ALTER TABLE `hanissearchrequest` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `hanissearchstatus`
--

DROP TABLE IF EXISTS `hanissearchstatus`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `hanissearchstatus` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) NOT NULL,
  `Description` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `hanissearchstatus`
--

LOCK TABLES `hanissearchstatus` WRITE;
/*!40000 ALTER TABLE `hanissearchstatus` DISABLE KEYS */;
INSERT INTO `hanissearchstatus` VALUES (1,'Inserted',''),(2,'Submitted',''),(3,'Received','');
/*!40000 ALTER TABLE `hanissearchstatus` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `imageconversionrequest`
--

DROP TABLE IF EXISTS `imageconversionrequest`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `imageconversionrequest` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `SourceImage` longblob NOT NULL,
  `ConvertedImage` longblob,
  `SourceImageFormat_ID` int NOT NULL,
  `CoversionImageFormat_ID` int NOT NULL,
  `DateInserted` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `DateUpdated` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `imageconversionrequest`
--

LOCK TABLES `imageconversionrequest` WRITE;
/*!40000 ALTER TABLE `imageconversionrequest` DISABLE KEYS */;
/*!40000 ALTER TABLE `imageconversionrequest` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `imageformat`
--

DROP TABLE IF EXISTS `imageformat`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `imageformat` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) NOT NULL,
  `Description` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `imageformat`
--

LOCK TABLES `imageformat` WRITE;
/*!40000 ALTER TABLE `imageformat` DISABLE KEYS */;
INSERT INTO `imageformat` VALUES (1,'WSQ',''),(2,'JPEG',''),(3,'BMP','');
/*!40000 ALTER TABLE `imageformat` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `notificationmessage`
--

DROP TABLE IF EXISTS `notificationmessage`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `notificationmessage` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `DestinationAddress` varchar(250) NOT NULL,
  `Message` varchar(1000) NOT NULL,
  `Sent` bit(1) NOT NULL,
  `NotificationMessageType_ID` int NOT NULL,
  `DateInserted` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `DateUpdated` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `notificationmessage`
--

LOCK TABLES `notificationmessage` WRITE;
/*!40000 ALTER TABLE `notificationmessage` DISABLE KEYS */;
/*!40000 ALTER TABLE `notificationmessage` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `notificationmessagetype`
--

DROP TABLE IF EXISTS `notificationmessagetype`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `notificationmessagetype` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) NOT NULL,
  `Description` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `notificationmessagetype`
--

LOCK TABLES `notificationmessagetype` WRITE;
/*!40000 ALTER TABLE `notificationmessagetype` DISABLE KEYS */;
INSERT INTO `notificationmessagetype` VALUES (1,'SMS',''),(2,'eMail','');
/*!40000 ALTER TABLE `notificationmessagetype` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `role`
--

DROP TABLE IF EXISTS `role`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `role` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(50) DEFAULT NULL,
  `description` varchar(250) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `role`
--

LOCK TABLES `role` WRITE;
/*!40000 ALTER TABLE `role` DISABLE KEYS */;
INSERT INTO `role` VALUES (1,'Jakuza',''),(2,'Administrator',''),(3,'CompanyAdministrator',''),(4,'BankStatementUser','');
/*!40000 ALTER TABLE `role` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `securitysession`
--

DROP TABLE IF EXISTS `securitysession`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `securitysession` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `Token` varchar(1000) DEFAULT NULL,
  `ExpiryDate` timestamp NULL DEFAULT NULL,
  `User_ID` int DEFAULT NULL,
  `DateInserted` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `DateUpdated` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `Active` int DEFAULT '1',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=166 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `securitysession`
--

LOCK TABLES `securitysession` WRITE;
/*!40000 ALTER TABLE `securitysession` DISABLE KEYS */;
INSERT INTO `securitysession` VALUES (1,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjIiLCJyb2xlIjoiVXNlciIsIm5iZiI6MTU3OTI2OTA1NywiZXhwIjoxNTc5MzU1NDU3LCJpYXQiOjE1NzkyNjkwNTd9.-VWva62Ra1tYCHK37-tgM-vO121bNNAU-3kiEAEd0cE','2020-01-18 11:51:13',2,'2020-01-17 13:51:13','2020-01-17 13:51:13',0),(2,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjIiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1NzkyOTA3MzYsImV4cCI6MTU3OTM3NzEzNiwiaWF0IjoxNTc5MjkwNzM2fQ.LpGMjGmy-UcaEoXVQLal5j78pkxEdeLe2w0lvrr6I0U','2020-01-18 17:52:19',2,'2020-01-17 19:52:18','2020-01-17 19:52:18',0),(3,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjIiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1NzkyOTA5NTUsImV4cCI6MTU3OTM3NzM1NSwiaWF0IjoxNTc5MjkwOTU1fQ.bKn3drCLdWtUrFwIeJEd7GBYhsEMR0WWkjeOXE5-EP0','2020-01-18 17:55:56',2,'2020-01-17 19:55:55','2020-01-17 19:55:55',0),(4,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjIiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1NzkyOTEwNDIsImV4cCI6MTU3OTM3NzQ0MiwiaWF0IjoxNTc5MjkxMDQyfQ.8_EWVeW_82ozL9J_gXnlIyeqUacZVpDMuLa-sAdeBmA','2020-01-18 17:57:24',2,'2020-01-17 19:57:23','2020-01-17 19:57:23',0),(5,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjIiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1NzkyOTEyMTEsImV4cCI6MTU3OTM3NzYxMSwiaWF0IjoxNTc5MjkxMjExfQ.zw4gf6-6HlS25uNoCCNX76X729reemRX-1MDqdlSh_k','2020-01-18 18:00:13',2,'2020-01-17 20:00:12','2020-01-17 20:00:12',0),(6,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjIiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1NzkyOTE0NTUsImV4cCI6MTU3OTM3Nzg1NSwiaWF0IjoxNTc5MjkxNDU1fQ.gvHB4B-mfzBA4qBbcu2cjIuLFB29w-fwPEHqUsYMmbc','2020-01-18 18:04:16',2,'2020-01-17 20:04:16','2020-01-17 20:04:16',0),(7,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjIiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1NzkyOTE2MjQsImV4cCI6MTU3OTM3ODAyNCwiaWF0IjoxNTc5MjkxNjI0fQ.lv_on4PargA6ebCtHIeyVzDqk4O-pZFnZRN9BryuWfQ','2020-01-18 18:07:05',2,'2020-01-17 20:07:05','2020-01-17 20:07:05',0),(8,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjIiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1NzkyOTE4MTIsImV4cCI6MTU3OTM3ODIxMiwiaWF0IjoxNTc5MjkxODEyfQ.9hkxZrzt9_ShBHJ3HazrVUlT8XahkRONZ-CgTuKV4A4','2020-01-18 18:10:13',2,'2020-01-17 20:10:13','2020-01-17 20:10:13',0),(9,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjIiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1NzkyOTI3NDMsImV4cCI6MTU3OTM3OTE0MiwiaWF0IjoxNTc5MjkyNzQzfQ._beJAaOGGLwa0TmpkJzOu1cbb6B5KpvUjKKiFdSZ0HE','2020-01-18 18:25:44',2,'2020-01-17 20:25:43','2020-01-17 20:25:43',0),(10,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjIiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1NzkyOTMwMzAsImV4cCI6MTU3OTM3OTQzMCwiaWF0IjoxNTc5MjkzMDMwfQ.RiCrJOd81GVVcUbx-wutM00MU-djrbdt3Pyf4to506I','2020-01-18 18:30:32',2,'2020-01-17 20:30:31','2020-01-17 20:30:31',0),(11,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjIiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1NzkyOTMxNTgsImV4cCI6MTU3OTM3OTU1OCwiaWF0IjoxNTc5MjkzMTU4fQ.wLh7HbqrqaDM549ZZhRX59gqOjxwIW7wCm2xG9Kpc0M','2020-01-18 18:32:39',2,'2020-01-17 20:32:38','2020-01-17 20:32:38',0),(12,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjIiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1NzkyOTM0OTMsImV4cCI6MTU3OTM3OTg5MywiaWF0IjoxNTc5MjkzNDkzfQ.-AHWPqXp_dmqFl__S_42RyG1ozxV24A3NgVxDwn5Nd4','2020-01-18 18:38:14',2,'2020-01-17 20:38:14','2020-01-17 20:38:14',0),(13,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjIiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1NzkyOTM2ODcsImV4cCI6MTU3OTM4MDA4NywiaWF0IjoxNTc5MjkzNjg3fQ.3UXllzmaeevFaUm7JyLoXhjyl-wYRHZHF70x9j1vVfY','2020-01-18 18:41:28',2,'2020-01-17 20:41:28','2020-01-17 20:41:28',0),(14,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjIiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1NzkyOTM3NjcsImV4cCI6MTU3OTM4MDE2NywiaWF0IjoxNTc5MjkzNzY3fQ.xTh8WS5MOKITbGI3fA8nBibjc6wxkyqVXhCGxPqGdkc','2020-01-18 18:42:48',2,'2020-01-17 20:42:48','2020-01-17 20:42:48',0),(15,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjIiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1NzkyOTM4MjgsImV4cCI6MTU3OTM4MDIyOCwiaWF0IjoxNTc5MjkzODI4fQ.Y-f0Rx6REEpeN7w9djMuiwhqpx-0ABNPq3ffxAiJCWo','2020-01-18 18:43:49',2,'2020-01-17 20:43:49','2020-01-17 20:43:49',0),(16,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjIiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1NzkyOTM4OTQsImV4cCI6MTU3OTM4MDI5NCwiaWF0IjoxNTc5MjkzODk0fQ.tql4_sKoevUm_Yn5oNS1fJuw_hHMinczpASQ4H6oUj4','2020-01-18 18:44:55',2,'2020-01-17 20:44:54','2020-01-17 20:44:54',0),(17,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjIiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1NzkyOTQwNzUsImV4cCI6MTU3OTM4MDQ3NSwiaWF0IjoxNTc5Mjk0MDc1fQ.GC8vW4NlauhsDbyaSebGcxadwgXmYc5qkONWCKZ7DY4','2020-01-18 18:47:56',2,'2020-01-17 20:47:56','2020-01-17 20:47:56',0),(18,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjIiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1NzkyOTQzOTEsImV4cCI6MTU3OTM4MDc5MSwiaWF0IjoxNTc5Mjk0MzkxfQ.-3xo2TkZR9xg_17jkAgPKyM6OYMfVk2qFYiMVe1-3ok','2020-01-18 18:53:12',2,'2020-01-17 20:53:12','2020-01-17 20:53:12',0),(19,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjIiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1NzkyOTQ2MTcsImV4cCI6MTU3OTI5ODIxNywiaWF0IjoxNTc5Mjk0NjE3fQ.Nrz4zLBK6NWo3jX7ICG5Nb5rOSHgovi2paUub9iIxUM','2020-01-18 18:56:58',2,'2020-01-17 20:56:58','2020-01-17 20:56:58',0),(20,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjIiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1NzkzMzA3ODQsImV4cCI6MTU3OTQxNzE4NCwiaWF0IjoxNTc5MzMwNzg0fQ.YscgEl-e8iXHZjPtI_B-nQxa5rmx4OXP6f2ZrQTssJo','2020-01-19 04:59:47',2,'2020-01-18 06:59:47','2020-01-18 06:59:47',0),(21,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjIiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1Nzk0MjU1MjQsImV4cCI6MTU3OTUxMTkyNCwiaWF0IjoxNTc5NDI1NTI0fQ.YfE8TbqWXoYyrmtOJISfiCRsB5-DfVmOpnGkWixTXgA','2020-01-20 07:18:46',2,'2020-01-19 09:18:45','2020-01-19 09:18:45',0),(22,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjIiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1Nzk0Mzg2MDAsImV4cCI6MTU3OTUyNTAwMCwiaWF0IjoxNTc5NDM4NjAwfQ.L6lE93BG0Rr9HKdBZYneH0YFiwihhHEZO1VSdyk0PYw','2020-01-20 10:56:41',2,'2020-01-19 12:56:41','2020-01-19 12:56:41',0),(23,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjIiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1Nzk1MzIzNjIsImV4cCI6MTU3OTYxODc2MiwiaWF0IjoxNTc5NTMyMzYyfQ.xDG7jYjCCAQvXXSXsajysEgcXjsaD3w3kD_7JRWl-3c','2020-01-21 12:59:24',2,'2020-01-20 14:59:24','2020-01-20 14:59:24',0),(24,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjIiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1Nzk1MzI0OTMsImV4cCI6MTU3OTYxODg5MywiaWF0IjoxNTc5NTMyNDkzfQ.shCL8eus7UnwAGYD4w9wi4AXwcFPQASxs0rK3Kl9I4g','2020-01-21 13:01:35',2,'2020-01-20 15:01:35','2020-01-20 15:01:35',0),(25,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjIiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1Nzk1MzI2NTUsImV4cCI6MTU3OTYxOTA1NSwiaWF0IjoxNTc5NTMyNjU1fQ.alJNnpf4nrAFmUFBV1BANyXFQdP6HLEZcSm4m3MiHX8','2020-01-21 13:04:16',2,'2020-01-20 15:04:15','2020-01-20 15:04:15',0),(26,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjIiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1Nzk1MzU4MTgsImV4cCI6MTU3OTYyMjIxOCwiaWF0IjoxNTc5NTM1ODE4fQ.cvJD8U1Ma4AuMuwDTe84YSV2WcKMTw_sLTIhBDI3hP8','2020-01-21 13:56:58',2,'2020-01-20 15:56:58','2020-01-20 15:56:58',0),(27,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjIiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1Nzk1MzU5MDIsImV4cCI6MTU3OTYyMjMwMiwiaWF0IjoxNTc5NTM1OTAyfQ.wgG-rkbDwA62DAHnfB6rtHZ0mGuHWjrquTincqmrQoM','2020-01-21 13:58:23',2,'2020-01-20 15:58:22','2020-01-20 15:58:22',0),(28,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjIiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1Nzk1MzYwMjcsImV4cCI6MTU3OTYyMjQyNywiaWF0IjoxNTc5NTM2MDI3fQ.z_eRWEJermQuTgyzDt7lFKvawssLQGL5DFay56ToBL0','2020-01-21 14:00:28',2,'2020-01-20 16:00:27','2020-01-20 16:00:27',0),(29,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjIiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1Nzk1NDQyMjcsImV4cCI6MTU3OTYzMDYyNywiaWF0IjoxNTc5NTQ0MjI3fQ.46WWVZrkCBdlVOn2gpAapulK6fYpFl5F7PeVSWmmhFA','2020-01-21 16:17:08',2,'2020-01-20 18:17:08','2020-01-20 18:17:08',0),(30,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjIiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1Nzk1NDQzNTcsImV4cCI6MTU3OTYzMDc1NywiaWF0IjoxNTc5NTQ0MzU3fQ.RhOmJ0MNFTGSt3_A-0yPmF1CUkTv5_yqoCTlgDsitM8','2020-01-21 16:19:18',2,'2020-01-20 18:19:18','2020-01-20 18:19:18',0),(31,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjIiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1Nzk1NDYwMzMsImV4cCI6MTU3OTYzMjQzMywiaWF0IjoxNTc5NTQ2MDMzfQ.XPgu4cuf7ZgFeEkrI2F0XYoadSrH4YkAaSzXqPD1SZM','2020-01-21 16:47:13',2,'2020-01-20 18:47:13','2020-01-20 18:47:13',0),(32,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjIiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1Nzk1NDY2MTAsImV4cCI6MTU3OTYzMzAxMCwiaWF0IjoxNTc5NTQ2NjEwfQ.A0Q76SlJh78kdIrWV9kdMDBySExP5oiuEdeSJ7levy0','2020-01-21 16:56:51',2,'2020-01-20 18:56:51','2020-01-20 18:56:51',0),(33,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjIiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1Nzk1NDkwODIsImV4cCI6MTU3OTYzNTQ4MiwiaWF0IjoxNTc5NTQ5MDgyfQ.Dblle8D-4FdATI0xYAKycZfNO-dvwFhvzmqLV4WIDW0','2020-01-21 17:38:03',2,'2020-01-20 19:38:03','2020-01-20 19:38:03',0),(34,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjIiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1Nzk1NTAwMjEsImV4cCI6MTU3OTYzNjQyMSwiaWF0IjoxNTc5NTUwMDIxfQ.nXljkBypS80ZM0qg4gV3ROl5uqGGlu0CTG16YuVu3To','2020-01-21 17:53:42',2,'2020-01-20 19:53:41','2020-01-20 19:53:41',0),(35,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjIiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1Nzk1NTAyMTEsImV4cCI6MTU3OTYzNjYxMSwiaWF0IjoxNTc5NTUwMjExfQ.QeJRqgqsJEiSdjN7uZLDsq8MPDGenR9VWXQ0y7SRMdQ','2020-01-21 17:56:52',2,'2020-01-20 19:56:52','2020-01-20 19:56:52',0),(36,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjIiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1Nzk1NTA1MDQsImV4cCI6MTU3OTYzNjkwNCwiaWF0IjoxNTc5NTUwNTA0fQ.oX4MiOIRG130k0mFOGTb4ZHGWUfY4XbaOTUTvl36oEs','2020-01-21 18:01:45',2,'2020-01-20 20:01:44','2020-01-20 20:01:44',1),(37,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1Nzk1NTIzMjksImV4cCI6MTU3OTYzODcyOCwiaWF0IjoxNTc5NTUyMzI5fQ.emAkCKqTYHK87KZeyUxRIDaAIgrM6gFfv0NEVW24T0I','2020-01-21 18:32:13',1,'2020-01-20 20:32:12','2020-01-20 20:32:12',0),(38,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODAzOTQyMTgsImV4cCI6MTU4MDQ4MDYxOCwiaWF0IjoxNTgwMzk0MjE4fQ.A2wQMSscINUppwn4drgvJOghs3V5MLfjbpVWBL1eZOk','2020-01-31 12:23:39',1,'2020-01-30 14:23:38','2020-01-30 14:23:38',0),(39,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODAzOTQ0OTAsImV4cCI6MTU4MDQ4MDg4OSwiaWF0IjoxNTgwMzk0NDkwfQ.1CiTSDir3D4TAh4kAY8L5eXFimErYoVKm__YJ8214QA','2020-01-31 12:28:11',1,'2020-01-30 14:28:10','2020-01-30 14:28:10',0),(40,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODAzOTQ2NDksImV4cCI6MTU4MDQ4MTA0OSwiaWF0IjoxNTgwMzk0NjQ5fQ.ncs-SP2Cc7BgbrkTGx9T686sid6sVbgs1pUVr3FebMY','2020-01-31 12:30:49',1,'2020-01-30 14:30:49','2020-01-30 14:30:49',0),(41,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODA0NzQ3NDYsImV4cCI6MTU4MDU2MTE0NiwiaWF0IjoxNTgwNDc0NzQ2fQ.vTTYja_BKeJ5I1GIPQ8gEv6kchXqNXPt0YvQPiJibyE','2020-02-01 10:45:47',1,'2020-01-31 12:45:46','2020-01-31 12:45:46',0),(42,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODA0NzUyOTgsImV4cCI6MTU4MDU2MTY5OCwiaWF0IjoxNTgwNDc1Mjk4fQ.Tq_idQG0hGrZS69d6U_25Ucf2mazHDZiKzePRgSkY-Y','2020-02-01 10:54:59',1,'2020-01-31 12:54:58','2020-01-31 12:54:58',0),(43,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODA0NzU4MDUsImV4cCI6MTU4MDU2MjIwNSwiaWF0IjoxNTgwNDc1ODA1fQ.CZqE6WBtq3MA_iKNODdG0WJEqWv3NLqNGiDoN_J2N-4','2020-02-01 11:03:26',1,'2020-01-31 13:03:25','2020-01-31 13:03:25',0),(44,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODA0NzU4NTYsImV4cCI6MTU4MDU2MjI1NiwiaWF0IjoxNTgwNDc1ODU2fQ.Sg-lbYjocQFqt7TWzowwfXqQ-SyhmocSlYIscIiOSEg','2020-02-01 11:04:17',1,'2020-01-31 13:04:16','2020-01-31 13:04:16',0),(45,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODA0NzY0NjIsImV4cCI6MTU4MDU2Mjg2MiwiaWF0IjoxNTgwNDc2NDYyfQ.VdnfamCUdoQDQeRnvonrspisvwdmVxER3jradoUmOvk','2020-02-01 11:14:22',1,'2020-01-31 13:14:22','2020-01-31 13:14:22',0),(46,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODA3NDgxMzAsImV4cCI6MTU4MDgzNDUzMCwiaWF0IjoxNTgwNzQ4MTMwfQ.JGMy3NTpM67pQRA7jngtAd9LYe7n_w8PuqKG3HZz8wQ','2020-02-04 14:42:10',1,'2020-02-03 16:42:10','2020-02-03 16:42:10',0),(47,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODA4MDU2MzEsImV4cCI6MTU4MDg5MjAzMCwiaWF0IjoxNTgwODA1NjMxfQ.w-V2zM_dfwEuIMT67MGvvmf2kS901vH4svjRULhvjBM','2020-02-05 06:40:31',1,'2020-02-04 08:40:31','2020-02-04 08:40:31',0),(48,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODA4MDU2MzUsImV4cCI6MTU4MDg5MjAzNSwiaWF0IjoxNTgwODA1NjM1fQ.EQdSLhx-iicABfTqgXl1Z5C1qoLyNbK6vN3EwLriT0U','2020-02-05 06:40:35',1,'2020-02-04 08:40:35','2020-02-04 08:40:35',0),(49,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODA4MDgyMzUsImV4cCI6MTU4MDg5NDYzNSwiaWF0IjoxNTgwODA4MjM1fQ.e5gbpAgi5OatvQiLrFSXejSRRsWk26luHvShyreo-2w','2020-02-05 07:23:56',1,'2020-02-04 09:23:55','2020-02-04 09:23:55',0),(50,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODA4MDgzNjIsImV4cCI6MTU4MDg5NDc2MiwiaWF0IjoxNTgwODA4MzYyfQ.YkVnNH0g1krTSUvN_F_dRV8oJRnAXKJDrFbCmIPoFJc','2020-02-05 07:26:02',1,'2020-02-04 09:26:02','2020-02-04 09:26:02',0),(51,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODA4MjIwMTUsImV4cCI6MTU4MDkwODQxNSwiaWF0IjoxNTgwODIyMDE1fQ.3a27tYgumPjB5Ap8Lep6raYTZHN-UFxDl62DyGUPI1A','2020-02-05 11:13:35',1,'2020-02-04 13:13:35','2020-02-04 13:13:35',0),(52,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODA4MjIwOTMsImV4cCI6MTU4MDkwODQ5MywiaWF0IjoxNTgwODIyMDkzfQ.cBJeML-BGRXkhb2t3h-WDjm25pDOR8ogXseyoh9J6Po','2020-02-05 11:14:53',1,'2020-02-04 13:14:53','2020-02-04 13:14:53',0),(53,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODA4MjIxMzMsImV4cCI6MTU4MDkwODUzMywiaWF0IjoxNTgwODIyMTMzfQ.IUuSWtDlgXDGghPJ3otZSvR0JhOjrMqmRcmhHdvcUkM','2020-02-05 11:15:33',1,'2020-02-04 13:15:33','2020-02-04 13:15:33',0),(54,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODA4MjIzNDMsImV4cCI6MTU4MDkwODc0MywiaWF0IjoxNTgwODIyMzQzfQ.uJXnXZZiPQzM7sph4-mNtX3Mtrp1b7GqzgY5eu-c2qM','2020-02-05 11:19:03',1,'2020-02-04 13:19:03','2020-02-04 13:19:03',0),(55,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODA4MjI0MjgsImV4cCI6MTU4MDkwODgyOCwiaWF0IjoxNTgwODIyNDI4fQ.eNnYM-kuvak4OqZgoB8ZFV3qqjhwwJOg69r24iMYPzE','2020-02-05 11:20:29',1,'2020-02-04 13:20:28','2020-02-04 13:20:28',0),(56,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODA4MjI5ODUsImV4cCI6MTU4MDkwOTM4NSwiaWF0IjoxNTgwODIyOTg1fQ.dsrtZ96NaNilEvMBZZ45U6uRr5t_Hbyi85Di9TKtjHg','2020-02-05 11:29:46',1,'2020-02-04 13:29:45','2020-02-04 13:29:45',0),(57,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODA4MjMzNzksImV4cCI6MTU4MDkwOTc3OSwiaWF0IjoxNTgwODIzMzc5fQ.cMDboSJYctx4BeHZJurEIaa1RnvWrLsKjlZmgrY5p0g','2020-02-05 11:36:19',1,'2020-02-04 13:36:19','2020-02-04 13:36:19',0),(58,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODA4MjM0MDQsImV4cCI6MTU4MDkwOTgwNCwiaWF0IjoxNTgwODIzNDA0fQ.iMpvsRT7vBLo4M-4iyT5mhFn9R_a5GELtYjuLEzw8TA','2020-02-05 11:36:45',1,'2020-02-04 13:36:44','2020-02-04 13:36:44',0),(59,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODA4MjM1ODgsImV4cCI6MTU4MDkwOTk4OCwiaWF0IjoxNTgwODIzNTg4fQ.F4wEfX0Oa9ILXxL2AocxLN6MEBAaREm-HbCeWfy_UQI','2020-02-05 11:39:49',1,'2020-02-04 13:39:48','2020-02-04 13:39:48',0),(60,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODA4MjM3MTEsImV4cCI6MTU4MDkxMDExMSwiaWF0IjoxNTgwODIzNzExfQ.UTLHt_pK6lyDob-LiHPgRTgDLiNJJwj33Mpf7_BTE1o','2020-02-05 11:41:52',1,'2020-02-04 13:41:51','2020-02-04 13:41:51',0),(61,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODA4MjM4NzMsImV4cCI6MTU4MDkxMDI3MywiaWF0IjoxNTgwODIzODczfQ.MThMVVhB9XzUr_BMvi53GdJ3aJLcC-QuOFudBjAMkqI','2020-02-05 11:44:33',1,'2020-02-04 13:44:33','2020-02-04 13:44:33',0),(62,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODA4MjM5NjIsImV4cCI6MTU4MDkxMDM2MiwiaWF0IjoxNTgwODIzOTYyfQ.DpdzkH00i5NdotkR-xp97q7XQa7ub1ofP4jtunwbc4g','2020-02-05 11:46:02',1,'2020-02-04 13:46:02','2020-02-04 13:46:02',0),(63,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODA4MjQxNzMsImV4cCI6MTU4MDkxMDU3MywiaWF0IjoxNTgwODI0MTczfQ.YVz79tcFKI9neC8cXi6Y5tQGHFpKtZCfjhC_-qlO4YU','2020-02-05 11:49:33',1,'2020-02-04 13:49:33','2020-02-04 13:49:33',0),(64,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODA4MjQ0MzIsImV4cCI6MTU4MDkxMDgzMiwiaWF0IjoxNTgwODI0NDMyfQ.bN6LwysO-lc_me04SWyMCUwlJl5EcX_AYTSImdUpAlA','2020-02-05 11:53:53',1,'2020-02-04 13:53:52','2020-02-04 13:53:52',0),(65,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODA4MjUwNzIsImV4cCI6MTU4MDkxMTQ3MiwiaWF0IjoxNTgwODI1MDcyfQ.y_oQKKf96P5IwuQv1_1VcLonoewt-4Ltmr9NHXr7cPc','2020-02-05 12:04:32',1,'2020-02-04 14:04:32','2020-02-04 14:04:32',0),(66,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODA4NDMxNDYsImV4cCI6MTU4MDkyOTU0NiwiaWF0IjoxNTgwODQzMTQ2fQ.VHP8CBdwaig98GkRw1KNc1gEwKxjTunqHpGGWT-uYPo','2020-02-05 17:05:47',1,'2020-02-04 19:05:46','2020-02-04 19:05:46',0),(67,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODA4NDM2NTEsImV4cCI6MTU4MDkzMDA1MSwiaWF0IjoxNTgwODQzNjUxfQ.rIT2IoPQbr51ZTuhqPQrKzuuF_hHTm8MPkh3GTsmJ20','2020-02-05 17:14:12',1,'2020-02-04 19:14:11','2020-02-04 19:14:11',0),(68,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODA4NDM3MzIsImV4cCI6MTU4MDkzMDEzMiwiaWF0IjoxNTgwODQzNzMyfQ.UeFMpVXrmHZMdJgmgln6_r_m7zBFjvoO2NQ0yvSKwmU','2020-02-05 17:15:32',1,'2020-02-04 19:15:32','2020-02-04 19:15:32',0),(69,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODA4NDQ1NjgsImV4cCI6MTU4MDkzMDk2OCwiaWF0IjoxNTgwODQ0NTY4fQ.hFWl3crgGvtG-rAAFXdJyUHx1qBLoV3wgIqaLDFmi4E','2020-02-05 17:29:29',1,'2020-02-04 19:29:28','2020-02-04 19:29:28',0),(70,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODA4NDQ3MDcsImV4cCI6MTU4MDkzMTEwNywiaWF0IjoxNTgwODQ0NzA3fQ.RMo_SvpyV2q5_1ZcNriW2hNU-KQfVSpahq50-BW1450','2020-02-05 17:31:48',1,'2020-02-04 19:31:47','2020-02-04 19:31:47',0),(71,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODA4NDQ4ODUsImV4cCI6MTU4MDkzMTI4NSwiaWF0IjoxNTgwODQ0ODg1fQ.eXbbjX7w8msYpdttu9KGe4CZ5fxPbbnhIWp5qhOdEGE','2020-02-05 17:34:45',1,'2020-02-04 19:34:45','2020-02-04 19:34:45',0),(72,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODA4NDUxNzIsImV4cCI6MTU4MDkzMTU3MiwiaWF0IjoxNTgwODQ1MTcyfQ.opeRGx8za0gyIV3-FJxQpb-vMiU7jffM3--sBmER9LY','2020-02-05 17:39:32',1,'2020-02-04 19:39:32','2020-02-04 19:39:32',0),(73,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODA4NDUyNjcsImV4cCI6MTU4MDkzMTY2NywiaWF0IjoxNTgwODQ1MjY3fQ.ZxSTw9fZI_YXNIB-9gCgLqwDPd2RndgCkseOhoBbM2g','2020-02-05 17:41:07',1,'2020-02-04 19:41:07','2020-02-04 19:41:07',0),(74,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODA4ODQzNDIsImV4cCI6MTU4MDk3MDc0MiwiaWF0IjoxNTgwODg0MzQyfQ.Y7QpCyK4v7m3mWt0VqkAy5QHuc0I0wwU0zyGePZXPFc','2020-02-06 04:32:23',1,'2020-02-05 06:32:22','2020-02-05 06:32:22',0),(75,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODA4OTA3MDcsImV4cCI6MTU4MDk3NzEwNywiaWF0IjoxNTgwODkwNzA3fQ.5FgUPqhkYkHl-yA8jzZulOWoTcF1a05t2wkMANX2hLg','2020-02-06 06:18:28',1,'2020-02-05 08:18:27','2020-02-05 08:18:27',0),(76,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODA4OTY2NDEsImV4cCI6MTU4MDk4MzA0MSwiaWF0IjoxNTgwODk2NjQxfQ.m_ulQwV2ukeZOrQWCi9OIQ7JsiOdAqmTp5rxv6vm510','2020-02-06 07:57:22',1,'2020-02-05 09:57:21','2020-02-05 09:57:21',0),(77,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODA4OTc2MDcsImV4cCI6MTU4MDk4NDAwNywiaWF0IjoxNTgwODk3NjA3fQ.wBkq8ib3EWJj8UyG4WTFdElPrxyd0bdWqvFHf5H0B78','2020-02-06 08:13:27',1,'2020-02-05 10:13:27','2020-02-05 10:13:27',0),(78,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODA4OTc3NjUsImV4cCI6MTU4MDk4NDE2NSwiaWF0IjoxNTgwODk3NzY1fQ.zzqYd8IfgurAzfSrwnwDjJN-VSttne_vkkbpyq4Q0i0','2020-02-06 08:16:05',1,'2020-02-05 10:16:05','2020-02-05 10:16:05',0),(79,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODA5MDcyNTgsImV4cCI6MTU4MDk5MzY1OCwiaWF0IjoxNTgwOTA3MjU4fQ.8A95tYyf_hkiXadi7JGUl_eDL5HgC5OuJR1cfCtDI28','2020-02-06 10:54:18',1,'2020-02-05 12:54:18','2020-02-05 12:54:18',0),(80,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODA5MDc1OTUsImV4cCI6MTU4MDk5Mzk5NSwiaWF0IjoxNTgwOTA3NTk1fQ.f3L99_Bq942Mka6E_oWkLKHayNBygp3Few4ce9Pffds','2020-02-06 10:59:56',1,'2020-02-05 12:59:56','2020-02-05 12:59:56',0),(81,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODA5MTA4NDcsImV4cCI6MTU4MDk5NzI0NywiaWF0IjoxNTgwOTEwODQ3fQ.LIhuC2Oz1NGW3fw5XHQhLB8vpW4RVmmJR5sCOXkQ2j4','2020-02-06 11:54:08',1,'2020-02-05 13:54:07','2020-02-05 13:54:07',0),(82,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODA5MTA5MzIsImV4cCI6MTU4MDk5NzMzMiwiaWF0IjoxNTgwOTEwOTMyfQ.Xj8Dd_movBLDeaiyjTbn75lhn5fXWkmP7Um1M_Ddy1Q','2020-02-06 11:55:33',1,'2020-02-05 13:55:32','2020-02-05 13:55:32',0),(83,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODA5MTEzMTgsImV4cCI6MTU4MDk5NzcxOCwiaWF0IjoxNTgwOTExMzE4fQ.dSoQ4BBMhd_0tsP7Lzid7ICcJGTqR-7HF7JQQL9pHLc','2020-02-06 12:01:58',1,'2020-02-05 14:01:58','2020-02-05 14:01:58',0),(84,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODA5MTQ4NjIsImV4cCI6MTU4MTAwMTI2MiwiaWF0IjoxNTgwOTE0ODYyfQ.hBTw-X-zEGKl_zNHyRvtCA0IRDEUM_ZwqyDgXENc_gE','2020-02-06 13:01:03',1,'2020-02-05 15:01:02','2020-02-05 15:01:02',0),(85,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODA5ODY2MTMsImV4cCI6MTU4MTA3MzAxMywiaWF0IjoxNTgwOTg2NjEzfQ.dQLiyosT7INmN6eo9Fy6-1xnUVmPRyEqBEwT4RRWNB0','2020-02-07 08:56:54',1,'2020-02-06 10:56:53','2020-02-06 10:56:53',0),(86,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODA5OTQ3NTQsImV4cCI6MTU4MTA4MTE1NCwiaWF0IjoxNTgwOTk0NzU0fQ.9hIRX1OXBrXhXxAcZTW3z0j70SlWfXksy37i7-USTRA','2020-02-07 11:12:34',1,'2020-02-06 13:12:34','2020-02-06 13:12:34',0),(87,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODA5OTQ3NzMsImV4cCI6MTU4MTA4MTE3MywiaWF0IjoxNTgwOTk0NzczfQ.63k09bSkQiHlrWL_45Bbn3wL-wP_oGduNpkq9DKByNk','2020-02-07 11:12:53',1,'2020-02-06 13:12:53','2020-02-06 13:12:53',0),(88,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODA5OTQ3NzksImV4cCI6MTU4MTA4MTE3OSwiaWF0IjoxNTgwOTk0Nzc5fQ.GPzmx1IbHoZbpduAeBBUMspuHS_vAHS--43MuSuMUxg','2020-02-07 11:13:00',1,'2020-02-06 13:12:59','2020-02-06 13:12:59',0),(89,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODA5OTQ4MTUsImV4cCI6MTU4MTA4MTIxNSwiaWF0IjoxNTgwOTk0ODE1fQ.YCqkVOlKzlQlBbdje13K16RZzhedtxr-yZn_3AfmF30','2020-02-07 11:13:35',1,'2020-02-06 13:13:35','2020-02-06 13:13:35',0),(90,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODA5OTQ4MzAsImV4cCI6MTU4MTA4MTIzMCwiaWF0IjoxNTgwOTk0ODMwfQ.pwhLFwZNck0-MEScaTBPDtEwBQZe-f5FmGbPTlnlzgk','2020-02-07 11:13:50',1,'2020-02-06 13:13:50','2020-02-06 13:13:50',0),(91,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODA5OTQ4NDYsImV4cCI6MTU4MTA4MTI0NiwiaWF0IjoxNTgwOTk0ODQ2fQ.HFfBTQ6Y_dK1OpUkKQDh1xIFyj-PYBQk6nuID5XAL_k','2020-02-07 11:14:07',1,'2020-02-06 13:14:06','2020-02-06 13:14:06',0),(92,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODA5OTQ4NTUsImV4cCI6MTU4MTA4MTI1NSwiaWF0IjoxNTgwOTk0ODU1fQ.7ZdT-Fc0KfJecCLmEO4msdVYab4mrqkG7mMI3iHZBw8','2020-02-07 11:14:16',1,'2020-02-06 13:14:15','2020-02-06 13:14:15',0),(93,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODA5OTQ4NTksImV4cCI6MTU4MTA4MTI1OSwiaWF0IjoxNTgwOTk0ODU5fQ.UEiP1PTccmr3VNSTJhjGOtsbzO7M9kdtIhraNzT6Rdc','2020-02-07 11:14:20',1,'2020-02-06 13:14:19','2020-02-06 13:14:19',0),(94,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODA5OTQ4ODEsImV4cCI6MTU4MTA4MTI4MSwiaWF0IjoxNTgwOTk0ODgxfQ.BXVXITZ80ATsmu5Fi0Dn3qkBJZxG4J1WqaGysNAU9mA','2020-02-07 11:14:42',1,'2020-02-06 13:14:41','2020-02-06 13:14:41',0),(95,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODA5OTQ4ODUsImV4cCI6MTU4MTA4MTI4NSwiaWF0IjoxNTgwOTk0ODg1fQ.XCCDetif4MWg3JIBn2E3mibC40aUzpjdC8uArZjdEns','2020-02-07 11:14:46',1,'2020-02-06 13:14:45','2020-02-06 13:14:45',0),(96,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODA5OTUwMzksImV4cCI6MTU4MTA4MTQzOSwiaWF0IjoxNTgwOTk1MDM5fQ.eVplpwA34vFDOcjxu2BhoI1Tbr4VwYrPqjh5ko4rww0','2020-02-07 11:17:19',1,'2020-02-06 13:17:19','2020-02-06 13:17:19',0),(97,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODA5OTUwNTIsImV4cCI6MTU4MTA4MTQ1MiwiaWF0IjoxNTgwOTk1MDUyfQ.49DZv1zmkhqYfltP5NQJ36ItF71xmoCCKLeoY3MswRM','2020-02-07 11:17:33',1,'2020-02-06 13:17:32','2020-02-06 13:17:32',0),(98,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODA5OTYxOTYsImV4cCI6MTU4MTA4MjU5NiwiaWF0IjoxNTgwOTk2MTk2fQ.r_i5Xs-SOlvursSaOaj-CxPQA84nwsqENXWe6x-HSnM','2020-02-07 11:36:36',1,'2020-02-06 13:36:36','2020-02-06 13:36:36',0),(99,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODA5OTY3MjIsImV4cCI6MTU4MTA4MzEyMiwiaWF0IjoxNTgwOTk2NzIyfQ.uVEyBYb4dA_H3hQXWYEjnqGJgVYj7rJ953E1ulqWi5k','2020-02-07 11:45:23',1,'2020-02-06 13:45:22','2020-02-06 13:45:22',0),(100,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODA5OTczNDQsImV4cCI6MTU4MTA4Mzc0NCwiaWF0IjoxNTgwOTk3MzQ0fQ.b5YIRaE6M6gLqfAbGsrRMq5Ulx7cxjE4c7WTAmEOCnk','2020-02-07 11:55:44',1,'2020-02-06 13:55:44','2020-02-06 13:55:44',0),(101,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODA5OTc0OTAsImV4cCI6MTU4MTA4Mzg5MCwiaWF0IjoxNTgwOTk3NDkwfQ.19Kdzzlw3JXIDHo8XbaQivk4LPLHZQ4ek6kXaxS6SYY','2020-02-07 11:58:10',1,'2020-02-06 13:58:10','2020-02-06 13:58:10',0),(102,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODA5OTc1NDIsImV4cCI6MTU4MTA4Mzk0MiwiaWF0IjoxNTgwOTk3NTQyfQ.Z-aJ-wWiPgkk55OTgrt8CVKQq_vRf6umdDZt3O2GdIU','2020-02-07 11:59:03',1,'2020-02-06 13:59:02','2020-02-06 13:59:02',0),(103,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODA5OTgzNzUsImV4cCI6MTU4MTA4NDc3NSwiaWF0IjoxNTgwOTk4Mzc1fQ.rB3VY4011ZhRUV9rAN28lvalt44XBZO4C8v6u2D-b48','2020-02-07 12:12:55',1,'2020-02-06 14:12:55','2020-02-06 14:12:55',0),(104,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODA5OTg0NzMsImV4cCI6MTU4MTA4NDg3MywiaWF0IjoxNTgwOTk4NDczfQ.C5JS4SEiWGY6XL5IDnFzrOkcH6xNYmIGHd2d9FKvjIc','2020-02-07 12:14:33',1,'2020-02-06 14:14:33','2020-02-06 14:14:33',0),(105,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODA5OTg1NDIsImV4cCI6MTU4MTA4NDk0MiwiaWF0IjoxNTgwOTk4NTQyfQ.vCI4LtovvqIXdy7jVaVqakxY0EV5-HgUOshF9jVyAyI','2020-02-07 12:15:42',1,'2020-02-06 14:15:42','2020-02-06 14:15:42',0),(106,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODA5OTg2MjYsImV4cCI6MTU4MTA4NTAyNiwiaWF0IjoxNTgwOTk4NjI2fQ.7XKzPYehVYf6XXBp8PBJibtI0mVCGRd0DzySDGjGp4g','2020-02-07 12:17:07',1,'2020-02-06 14:17:06','2020-02-06 14:17:06',0),(107,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODA5OTg4MjAsImV4cCI6MTU4MTA4NTIyMCwiaWF0IjoxNTgwOTk4ODIwfQ.KpjG094Ihi26DDspzOf66svK74CBJDHRh1QJ-i_gVNs','2020-02-07 12:20:21',1,'2020-02-06 14:20:20','2020-02-06 14:20:20',0),(108,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODA5OTkxODksImV4cCI6MTU4MTA4NTU4OSwiaWF0IjoxNTgwOTk5MTg5fQ.YN6qH0NlQi58FhoaEWKaZFABjjIxhRG0khEKSfkv96c','2020-02-07 12:26:29',1,'2020-02-06 14:26:29','2020-02-06 14:26:29',0),(109,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODA5OTkzNzMsImV4cCI6MTU4MTA4NTc3MywiaWF0IjoxNTgwOTk5MzczfQ.ings4Ga0C6eEW77aDcHkU5g8T3INq7NQTydMC-_kL1o','2020-02-07 12:29:33',1,'2020-02-06 14:29:33','2020-02-06 14:29:33',0),(110,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODExMDA0MTcsImV4cCI6MTU4MTE4NjgxNywiaWF0IjoxNTgxMTAwNDE3fQ.TW5_p8EC5iWxHa20XukDs5MlKfYXTljeEVNVqsC9dGc','2020-02-08 16:33:38',1,'2020-02-07 18:33:37','2020-02-07 18:33:37',0),(111,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODExMDA0NjEsImV4cCI6MTU4MTE4Njg2MSwiaWF0IjoxNTgxMTAwNDYxfQ._hq_QkIMVWCvGWjDduTNoFxJWp_NxaB8YG4xlXaISQQ','2020-02-08 16:34:21',1,'2020-02-07 18:34:21','2020-02-07 18:34:21',0),(112,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODExMDA1NjksImV4cCI6MTU4MTE4Njk2OSwiaWF0IjoxNTgxMTAwNTY5fQ.ctEhw3SLMoxlOcNoJenYPEmbN-w4n02JVE2dJdRaoQc','2020-02-08 16:36:10',1,'2020-02-07 18:36:09','2020-02-07 18:36:09',0),(113,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODExMDA4ODUsImV4cCI6MTU4MTE4NzI4NSwiaWF0IjoxNTgxMTAwODg1fQ.RplLg-PRUrOPFO3zsV3ESIhIp_KQganLLAPe_Huh91k','2020-02-08 16:41:25',1,'2020-02-07 18:41:25','2020-02-07 18:41:25',0),(114,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODExMDEyOTgsImV4cCI6MTU4MTE4NzY5OCwiaWF0IjoxNTgxMTAxMjk4fQ.7FWb9mZILLgWJmG0zwhG1hk9s1ri0RIi0KJizGh-m3M','2020-02-08 16:48:18',1,'2020-02-07 18:48:18','2020-02-07 18:48:18',0),(115,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODExMDE4MTEsImV4cCI6MTU4MTE4ODIxMSwiaWF0IjoxNTgxMTAxODExfQ.G_5WgT4evAy035nMsDhPQvFgGAUVpmR1-UBvKe35F9s','2020-02-08 16:56:52',1,'2020-02-07 18:56:51','2020-02-07 18:56:51',0),(116,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODExMDIyODMsImV4cCI6MTU4MTE4ODY4MywiaWF0IjoxNTgxMTAyMjgzfQ.9iA5hChUiJZzTQV5g1zVIX0u2VwBPKsGnngvFeCgU5I','2020-02-08 17:04:43',1,'2020-02-07 19:04:43','2020-02-07 19:04:43',0),(117,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODExNTkwNTUsImV4cCI6MTU4MTI0NTQ1NSwiaWF0IjoxNTgxMTU5MDU1fQ.xB2oRun6Ihem-Re9wsWduziLWuJ7cupfYW_bHeVd-vY','2020-02-09 08:50:56',1,'2020-02-08 10:50:55','2020-02-08 10:50:55',0),(118,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODExNjA2NDIsImV4cCI6MTU4MTI0NzA0MiwiaWF0IjoxNTgxMTYwNjQyfQ.lqj4zveyMR6sXT8mYU7u8SAbbdeW8z7QLRdX91oLly8','2020-02-09 09:17:22',1,'2020-02-08 11:17:22','2020-02-08 11:17:22',0),(119,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODExNjIxMzEsImV4cCI6MTU4MTI0ODUzMSwiaWF0IjoxNTgxMTYyMTMxfQ.DIDrTjqot6nFJE8RKyQVsgFj_6_QXlnaiiOZKLxDbrE','2020-02-09 09:42:12',1,'2020-02-08 11:42:11','2020-02-08 11:42:11',0),(120,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODExNzI2NTYsImV4cCI6MTU4MTI1OTA1NiwiaWF0IjoxNTgxMTcyNjU2fQ.taB_8vzp6B6KJNCjNLQi5dEVL6SrCjJVwJLdF1Aest8','2020-02-09 12:37:36',1,'2020-02-08 14:37:36','2020-02-08 14:37:36',0),(121,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODExNzI4NTMsImV4cCI6MTU4MTI1OTI1MywiaWF0IjoxNTgxMTcyODUzfQ.tzgPXFaJmnu2t8SJrhAA1d7JhUbOER_LQGHpGB9_zb8','2020-02-09 12:40:54',1,'2020-02-08 14:40:53','2020-02-08 14:40:53',0),(122,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODExNzM4ODQsImV4cCI6MTU4MTI2MDI4NCwiaWF0IjoxNTgxMTczODg0fQ.113oxDFKvtsUjPzlC2BpEDc0KogV0KF-doq_xEHNhtY','2020-02-09 12:58:05',1,'2020-02-08 14:58:04','2020-02-08 14:58:04',0),(123,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODEyMjgzNjcsImV4cCI6MTU4MTMxNDc2NywiaWF0IjoxNTgxMjI4MzY3fQ.1hltrwkGwzr0-XbwZDc4H6KmmTmmCZMwMymv28TXJdE','2020-02-10 04:06:07',1,'2020-02-09 06:06:07','2020-02-09 06:06:07',0),(124,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODEyMjg2MTMsImV4cCI6MTU4MTMxNTAxMywiaWF0IjoxNTgxMjI4NjEzfQ.ErO_rpg7z3bus_-DP1X8gGGPt3fOnkGi9FpVa6U--QU','2020-02-10 04:10:14',1,'2020-02-09 06:10:14','2020-02-09 06:10:14',0),(125,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODEyMjg4MjYsImV4cCI6MTU4MTMxNTIyNiwiaWF0IjoxNTgxMjI4ODI2fQ.du7kExx0sh9WP1-E4U2NIHmTyBbzohJnATVFpZ1-7iI','2020-02-10 04:13:47',1,'2020-02-09 06:13:46','2020-02-09 06:13:46',0),(126,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODEyMzM5MjIsImV4cCI6MTU4MTMyMDMyMiwiaWF0IjoxNTgxMjMzOTIyfQ.Koxw4ua17FGMbcMyy9XFfZJb7xP0Xj9QUyJBgDNZIq0','2020-02-10 05:38:42',1,'2020-02-09 07:38:42','2020-02-09 07:38:42',0),(127,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODEyMzM5MjUsImV4cCI6MTU4MTMyMDMyNSwiaWF0IjoxNTgxMjMzOTI1fQ.Fw3-9Mm_5c4ExwNFFdInySJbYZkyZ83x9mDxWeyMZ7E','2020-02-10 05:38:46',1,'2020-02-09 07:38:45','2020-02-09 07:38:45',0),(128,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODEyNTM2NTEsImV4cCI6MTU4MTM0MDA1MSwiaWF0IjoxNTgxMjUzNjUxfQ.VsWoOLi0hSqMOw9jU-7INZ5lsWPd8CCHpf9eadamQ9I','2020-02-10 11:07:32',1,'2020-02-09 13:07:32','2020-02-09 13:07:32',0),(129,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODEzNDg2OTAsImV4cCI6MTU4MTQzNTA5MCwiaWF0IjoxNTgxMzQ4NjkwfQ.fm7AEUjJApM2mMrtEEyQ4P0j609eqjMtg10Ldacu3Cc','2020-02-11 13:31:31',1,'2020-02-10 15:31:31','2020-02-10 15:31:31',0),(130,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODE0MDA2MTYsImV4cCI6MTU4MTQ4NzAxNiwiaWF0IjoxNTgxNDAwNjE2fQ.s7rt1rKrwpfbtk31EKRKXmaVgRABjfQ7VVin3PgzRtU','2020-02-12 03:56:56',1,'2020-02-11 05:56:56','2020-02-11 05:56:56',0),(131,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODE0MDU3MDcsImV4cCI6MTU4MTQ5MjEwNywiaWF0IjoxNTgxNDA1NzA3fQ.TlhUQYFo_mScHc2oPmUOnM07AbroS25LgLJNaN9MOe4','2020-02-12 05:21:48',1,'2020-02-11 07:21:47','2020-02-11 07:21:47',0),(132,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODE0MDc1NDEsImV4cCI6MTU4MTQ5Mzk0MSwiaWF0IjoxNTgxNDA3NTQxfQ.1JyfLGfgqpIzsC59xI8Ju5dcAOvKw_FjL6pmefogKsw','2020-02-12 05:52:21',1,'2020-02-11 07:52:21','2020-02-11 07:52:21',0),(133,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODE1MDI4MjIsImV4cCI6MTU4MTU4OTIyMiwiaWF0IjoxNTgxNTAyODIyfQ.tSP6_KNZBfpXEjQ9t23VqzdY3KtnMGuIL_QHJpMO03U','2020-02-13 08:20:22',1,'2020-02-12 10:20:22','2020-02-12 10:20:22',0),(134,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODE1MjkwNTQsImV4cCI6MTU4MTYxNTQ1NCwiaWF0IjoxNTgxNTI5MDU0fQ.OhnZ-vaPBFx0CjRPlfD_h2JecXwwA8xilxBWLCUsOAg','2020-02-13 15:37:35',1,'2020-02-12 17:37:34','2020-02-12 17:37:34',0),(135,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODE1MjkxOTQsImV4cCI6MTU4MTYxNTU5NCwiaWF0IjoxNTgxNTI5MTk0fQ.JnwHpDs9-rxpAi932ba-Tyfgf_-xbJLz1T6wV3QZYoQ','2020-02-13 15:39:54',1,'2020-02-12 17:39:54','2020-02-12 17:39:54',0),(136,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODE1MzA5NTgsImV4cCI6MTU4MTYxNzM1OCwiaWF0IjoxNTgxNTMwOTU4fQ.zPL2zpblCYj7-p7gQrXZNBhsnR9a8bhAvPapIpteMKE','2020-02-13 16:09:19',1,'2020-02-12 18:09:18','2020-02-12 18:09:18',0),(137,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODE1MzE1NjIsImV4cCI6MTU4MTYxNzk2MiwiaWF0IjoxNTgxNTMxNTYyfQ.B6omw8I-XqX-Sv5-0s5tSuMAH1aNXs2kkrOlKBucoVk','2020-02-13 16:19:23',1,'2020-02-12 18:19:23','2020-02-12 18:19:23',0),(138,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODE1MzI0NTksImV4cCI6MTU4MTYxODg1OSwiaWF0IjoxNTgxNTMyNDU5fQ.VxTm2kF9BAjLuZbKu6E70p4kkPIrtXMiBvKu1-hu-Y0','2020-02-13 16:34:20',1,'2020-02-12 18:34:19','2020-02-12 18:34:19',0),(139,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODE1MzM3NjQsImV4cCI6MTU4MTYyMDE2NCwiaWF0IjoxNTgxNTMzNzY0fQ.ceAPmUVFUuqTC895hhNTz0aOJxhy6VpHZXJig-eRrq8','2020-02-13 16:56:05',1,'2020-02-12 18:56:04','2020-02-12 18:56:04',0),(140,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODE1MzQ2ODMsImV4cCI6MTU4MTYyMTA4MywiaWF0IjoxNTgxNTM0NjgzfQ.R-2W-aVLakBGdwQ84ENy9aphzaP0t5RJ9oCklvq6b6Q','2020-02-13 17:11:23',1,'2020-02-12 19:11:23','2020-02-12 19:11:23',0),(141,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODE1MzQ5MTksImV4cCI6MTU4MTYyMTMxOSwiaWF0IjoxNTgxNTM0OTE5fQ.6PuU4hQq3iGgFWfS0cZ3XIv3E2sTWMrf7PBe6bjSY0g','2020-02-13 17:15:19',1,'2020-02-12 19:15:19','2020-02-12 19:15:19',0),(142,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODE1MzU2NDAsImV4cCI6MTU4MTYyMjA0MCwiaWF0IjoxNTgxNTM1NjQwfQ.siIJ720ublSDWuCO1YYj77CEzR9LsLGc4TFgdIK_HP4','2020-02-13 17:27:21',1,'2020-02-12 19:27:20','2020-02-12 19:27:20',0),(143,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODE1MzU2OTEsImV4cCI6MTU4MTYyMjA5MSwiaWF0IjoxNTgxNTM1NjkxfQ.B2x3RVoWfPlbn7jgxCM_yYzQuEXH6KuyHgKii5yA0Zk','2020-02-13 17:28:12',1,'2020-02-12 19:28:11','2020-02-12 19:28:11',0),(144,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODE2Njk3MjAsImV4cCI6MTU4MTc1NjEyMCwiaWF0IjoxNTgxNjY5NzIwfQ.K_osHCfEfjeoWEH9JJWIOUDrl61jShiU-p7dqp0aRas','2020-02-15 06:42:01',1,'2020-02-14 08:42:00','2020-02-14 08:42:00',0),(145,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODE2Njk5MTQsImV4cCI6MTU4MTc1NjMxNCwiaWF0IjoxNTgxNjY5OTE0fQ.jLSmLZfmKYqfmYxr3QBLd9Tj4wDBIReiHz7JCWooX2A','2020-02-15 06:45:14',1,'2020-02-14 08:45:14','2020-02-14 08:45:14',0),(146,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODE3NzkzODMsImV4cCI6MTU4MTg2NTc4MywiaWF0IjoxNTgxNzc5MzgzfQ.gWlrgEi8iZC5Q7DLBSeNuIaba2BAOrYZ1SFxbpPhU2E','2020-02-16 13:09:43',1,'2020-02-15 15:09:43','2020-02-15 15:09:43',0),(147,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODE4NzYyMTUsImV4cCI6MTU4MTk2MjYxNSwiaWF0IjoxNTgxODc2MjE1fQ.VAPIhVHKdJx05t6OHNMFQSZqPxWZv1qmR5spjdH0Fuo','2020-02-17 16:03:36',1,'2020-02-16 18:03:35','2020-02-16 18:03:35',0),(148,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODE4NzYzMTgsImV4cCI6MTU4MTk2MjcxOCwiaWF0IjoxNTgxODc2MzE4fQ.iMtEQpITRONmhiRYs32MxeAkB8dnaI3KxDBE_r7TBtc','2020-02-17 16:05:18',1,'2020-02-16 18:05:18','2020-02-16 18:05:18',0),(149,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODE5MjU1NjgsImV4cCI6MTU4MjAxMTk2OCwiaWF0IjoxNTgxOTI1NTY4fQ.rzPDgBr44cs3WXlJC4uzcnV4b5i4o8jdgge-ottBL28','2020-02-18 05:46:09',1,'2020-02-17 07:46:09','2020-02-17 07:46:09',0),(150,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODIxMDU3NjYsImV4cCI6MTU4MjE5MjE2NiwiaWF0IjoxNTgyMTA1NzY2fQ.Xw0I364BtHuA-NeAQyjot3VCRnCh6iZEJ0Jaf93rgEE','2020-02-20 07:49:26',1,'2020-02-19 09:49:26','2020-02-19 09:49:26',0),(151,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODIyODk1NDIsImV4cCI6MTU4MjM3NTk0MiwiaWF0IjoxNTgyMjg5NTQyfQ.r8WqWOYPxzrnXVNCpB5_FbQglUPhRsSKTgOoXRMz22M','2020-02-22 10:52:22',1,'2020-02-21 12:52:22','2020-02-21 12:52:22',0),(152,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODIyOTAxMzMsImV4cCI6MTU4MjM3NjUzMywiaWF0IjoxNTgyMjkwMTMzfQ._ZoXjd9vpi2CkxzZYYr53UxhZHPVhJMxQ7MO_IEdgns','2020-02-22 11:02:13',1,'2020-02-21 13:02:13','2020-02-21 13:02:13',0),(153,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODI0NTI4OTQsImV4cCI6MTU4MjUzOTI5NCwiaWF0IjoxNTgyNDUyODk0fQ.LgQFlYGHjQ762yrZozVMokSO6QD3UiUteo17YEgmhi0','2020-02-24 08:14:54',1,'2020-02-23 10:14:54','2020-02-23 10:14:54',0),(154,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODI0NTQ5MTcsImV4cCI6MTU4MjU0MTMxNywiaWF0IjoxNTgyNDU0OTE3fQ.I-Av4wy8Fo4CT-KtImMWSLQsgyPsVSYI8nBJVQj6nMI','2020-02-24 08:48:37',1,'2020-02-23 10:48:37','2020-02-23 10:48:37',0),(155,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODI1Mjk4NTYsImV4cCI6MTU4MjYxNjI1NiwiaWF0IjoxNTgyNTI5ODU2fQ.GZmxaRrqWMSVP5_nM9YKujpy8TGjKBB5ixRy0apuWx8','2020-02-25 05:37:37',1,'2020-02-24 07:37:37','2020-02-24 07:37:37',0),(156,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODI1MzkzMjUsImV4cCI6MTU4MjYyNTcyNSwiaWF0IjoxNTgyNTM5MzI1fQ.hsYcgMOsDEgdGDQwqGXYIm9QVlOm8nki4NLA97qClSg','2020-02-25 08:15:26',1,'2020-02-24 10:15:25','2020-02-24 10:15:25',0),(157,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODI1NTA5OTksImV4cCI6MTU4MjYzNzM5OSwiaWF0IjoxNTgyNTUwOTk5fQ.C1EKR-ymNvrY17IMhoUjq3ctGKRDfOuBA5-_vXMmKlk','2020-02-25 11:30:00',1,'2020-02-24 13:29:59','2020-02-24 13:29:59',0),(158,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODI1Njg4MDYsImV4cCI6MTU4MjY1NTIwNiwiaWF0IjoxNTgyNTY4ODA2fQ.POnMoH3pLnLazFupjaQqp6tSrCIXSKRpUlVhCzFQKk4','2020-02-25 16:26:47',1,'2020-02-24 18:26:46','2020-02-24 18:26:46',0),(159,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODI2MTg1MjYsImV4cCI6MTU4MjcwNDkyNiwiaWF0IjoxNTgyNjE4NTI2fQ.9tgVxOiQhAdVjd361NDbY3FzExOBhGwvUMlR6_Jw0_Y','2020-02-26 06:15:27',1,'2020-02-25 08:15:26','2020-02-25 08:15:26',0),(160,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODI3MDczNzQsImV4cCI6MTU4Mjc5Mzc3NCwiaWF0IjoxNTgyNzA3Mzc0fQ.6y0HAQWE02QEm8jZIvEppdEBEUoRv0HkbEW0b6fnSYI','2020-02-27 06:56:15',1,'2020-02-26 08:56:14','2020-02-26 08:56:14',0),(161,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODI4NzI1OTQsImV4cCI6MTU4Mjk1ODk5NCwiaWF0IjoxNTgyODcyNTk0fQ.RBzLPi5QG5E5q5Hc5OaeQWmEWDFbAZTnBrEWNvujLp8','2020-02-29 04:49:55',1,'2020-02-28 06:49:54','2020-02-28 06:49:54',0),(162,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODMwNzcxNDAsImV4cCI6MTU4MzE2MzU0MCwiaWF0IjoxNTgzMDc3MTQwfQ.uxbNfeW3kD6vEuRtW0BfzfOQsEu7jDSU7QQME_3PtEo','2020-03-02 13:39:01',1,'2020-03-01 15:39:00','2020-03-01 15:39:00',0),(163,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODMxNTM5NjIsImV4cCI6MTU4MzI0MDM2MiwiaWF0IjoxNTgzMTUzOTYyfQ.Qtg5VkKmEcFp2eFrWxuHCJnr6q5uK8PnVGQdrnZ9uTc','2020-03-03 10:59:23',1,'2020-03-02 12:59:22','2020-03-02 12:59:22',0),(164,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODMyMjYyNTYsImV4cCI6MTU4MzMxMjY1NiwiaWF0IjoxNTgzMjI2MjU2fQ.AncUSZOJphMWZ_PpoVW4R6PHnCTpfJVLccSxkrPM4C4','2020-03-04 07:04:16',1,'2020-03-03 09:04:16','2020-03-03 09:04:16',0),(165,'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQmFua1N0YXRlbWVudFVzZXIiLCJuYmYiOjE1ODQwODk4ODQsImV4cCI6MTU4NDE3NjI4NCwiaWF0IjoxNTg0MDg5ODg0fQ.qXUEvLHrykGXriDmLieL4mY9idNToihzVHpBx7x6068','2020-03-14 06:58:05',1,'2020-03-13 08:58:05','2020-03-13 08:58:05',1);
/*!40000 ALTER TABLE `securitysession` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tagname`
--

DROP TABLE IF EXISTS `tagname`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tagname` (
  `id` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) DEFAULT NULL,
  `Description` varchar(250) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tagname`
--

LOCK TABLES `tagname` WRITE;
/*!40000 ALTER TABLE `tagname` DISABLE KEYS */;
INSERT INTO `tagname` VALUES (1,'BankName',''),(2,'BVSessionID','');
/*!40000 ALTER TABLE `tagname` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `thirdparty_audit`
--

DROP TABLE IF EXISTS `thirdparty_audit`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `thirdparty_audit` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `Thirdparty_ID` int DEFAULT NULL,
  `UniqueReference` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `thirdparty_audit`
--

LOCK TABLES `thirdparty_audit` WRITE;
/*!40000 ALTER TABLE `thirdparty_audit` DISABLE KEYS */;
/*!40000 ALTER TABLE `thirdparty_audit` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `uniqueidentifiertype`
--

DROP TABLE IF EXISTS `uniqueidentifiertype`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `uniqueidentifiertype` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) NOT NULL,
  `Description` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `uniqueidentifiertype`
--

LOCK TABLES `uniqueidentifiertype` WRITE;
/*!40000 ALTER TABLE `uniqueidentifiertype` DISABLE KEYS */;
INSERT INTO `uniqueidentifiertype` VALUES (1,'ID',''),(2,'Passport',''),(3,'MobileNumber','');
/*!40000 ALTER TABLE `uniqueidentifiertype` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `FirstName` varchar(50) DEFAULT NULL,
  `LastName` varchar(50) DEFAULT NULL,
  `UserName` varchar(100) DEFAULT NULL,
  `Password` varchar(100) DEFAULT NULL,
  `EmailAddress` varchar(250) DEFAULT NULL,
  `MobileNumber` varchar(15) DEFAULT NULL,
  `Active` int DEFAULT NULL,
  `DateInserted` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `DateUpdated` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user`
--

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` VALUES (1,'Willie','Botha','user','user','xwilus@gmail.com','0834082164',1,'2020-01-20 20:25:10','2020-01-20 20:25:10');
/*!40000 ALTER TABLE `user` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `verificationbiometric`
--

DROP TABLE IF EXISTS `verificationbiometric`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `verificationbiometric` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `BiometricType_ID` int NOT NULL,
  `BiometricImage` longblob NOT NULL,
  `BiometricPosition` varchar(100) NOT NULL,
  `DateInserted` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `DateUpdated` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `VerificationRequest_ID` int NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `verificationbiometric`
--

LOCK TABLES `verificationbiometric` WRITE;
/*!40000 ALTER TABLE `verificationbiometric` DISABLE KEYS */;
/*!40000 ALTER TABLE `verificationbiometric` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `verificationrequest`
--

DROP TABLE IF EXISTS `verificationrequest`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `verificationrequest` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `SourceID` varchar(100) NOT NULL,
  `UniqueIdentifier` varchar(100) NOT NULL,
  `UniqueIdentifierType_ID` int NOT NULL,
  `TransactionReference` varchar(100) NOT NULL,
  `DateInserted` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `DateUpdated` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `EnrolmentRequest_ID` int NOT NULL,
  `VerificationStatus_ID` int NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `verificationrequest`
--

LOCK TABLES `verificationrequest` WRITE;
/*!40000 ALTER TABLE `verificationrequest` DISABLE KEYS */;
/*!40000 ALTER TABLE `verificationrequest` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `verificationrequest_notificationmessage`
--

DROP TABLE IF EXISTS `verificationrequest_notificationmessage`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `verificationrequest_notificationmessage` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `VerificationRequest_ID` int NOT NULL,
  `NotificationMessage_ID` int NOT NULL,
  `DateInserted` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `DateUpdated` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `verificationrequest_notificationmessage`
--

LOCK TABLES `verificationrequest_notificationmessage` WRITE;
/*!40000 ALTER TABLE `verificationrequest_notificationmessage` DISABLE KEYS */;
/*!40000 ALTER TABLE `verificationrequest_notificationmessage` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `verificationstatus`
--

DROP TABLE IF EXISTS `verificationstatus`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `verificationstatus` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) NOT NULL,
  `Description` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `verificationstatus`
--

LOCK TABLES `verificationstatus` WRITE;
/*!40000 ALTER TABLE `verificationstatus` DISABLE KEYS */;
INSERT INTO `verificationstatus` VALUES (1,'Verified',''),(2,'NotVerified',''),(3,'Error','');
/*!40000 ALTER TABLE `verificationstatus` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-03-27 14:43:18
