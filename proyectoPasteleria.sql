-- MySQL dump 10.13  Distrib 8.0.36, for Win64 (x86_64)
--
-- Host: localhost    Database: proyectopasteleria
-- ------------------------------------------------------
-- Server version	8.0.36

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
-- Table structure for table `categoria`
--

DROP TABLE IF EXISTS `categoria`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `categoria` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(50) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `categoria`
--

LOCK TABLES `categoria` WRITE;
/*!40000 ALTER TABLE `categoria` DISABLE KEYS */;
INSERT INTO `categoria` VALUES (2,'Cumpleaños'),(3,'Bodas'),(4,'Chocolate'),(5,'Frutas');
/*!40000 ALTER TABLE `categoria` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ingrediente`
--

DROP TABLE IF EXISTS `ingrediente`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ingrediente` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `IdPastel` int NOT NULL,
  `Nombre` varchar(100) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IdPastel` (`IdPastel`),
  CONSTRAINT `ingrediente_ibfk_1` FOREIGN KEY (`IdPastel`) REFERENCES `pastel` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=177 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ingrediente`
--

LOCK TABLES `ingrediente` WRITE;
/*!40000 ALTER TABLE `ingrediente` DISABLE KEYS */;
INSERT INTO `ingrediente` VALUES (6,1,'Harina de trigo'),(7,1,'Cacao belga premium'),(8,1,'Mantequilla'),(9,1,'Huevos frescos'),(10,1,'Crema para batir'),(11,1,'Chocolate semiamargo'),(12,2,'Harina de trigo'),(13,2,'Fresas frescas'),(14,2,'Crema para batir'),(15,2,'Azúcar'),(16,2,'Huevos'),(17,3,'Harina premium'),(18,3,'Fondant'),(19,3,'Vainilla natural'),(20,3,'Huevos'),(21,3,'Mantequilla'),(22,4,'Harina de trigo'),(23,4,'Vainilla natural'),(24,4,'Mantequilla'),(25,4,'Huevos'),(26,4,'Frutos rojos'),(27,5,'Zanahoria rallada'),(28,5,'Nueces'),(29,5,'Canela'),(30,5,'Harina'),(31,5,'Queso crema'),(32,6,'Limón natural'),(33,6,'Harina'),(34,6,'Azúcar'),(35,6,'Huevos'),(36,6,'Merengue'),(97,7,'Harina de trigo'),(98,7,'Vainilla'),(99,7,'Colorantes comestibles'),(100,7,'Crema batida'),(101,8,'Harina'),(102,8,'Chispas de colores'),(103,8,'Azúcar'),(104,8,'Mantequilla'),(105,9,'Fondant'),(106,9,'Vainilla premium'),(107,9,'Mantequilla'),(108,9,'Azúcar glass'),(109,10,'Harina'),(110,10,'Confetti comestible'),(111,10,'Huevos'),(112,10,'Crema'),(113,11,'Harina'),(114,11,'Fondant de dinosaurio'),(115,11,'Colorantes'),(116,11,'Chocolate blanco'),(117,12,'Harina premium'),(118,12,'Crema chantilly'),(119,12,'Azúcar'),(120,12,'Fondant blanco'),(121,13,'Flores naturales'),(122,13,'Vainilla'),(123,13,'Crema ligera'),(124,13,'Harina fina'),(125,14,'Cacao blanco'),(126,14,'Marmoleado de chocolate'),(127,14,'Mantequilla'),(128,14,'Vainilla'),(129,15,'Vainilla francesa'),(130,15,'Hojuelas doradas'),(131,15,'Harina'),(132,15,'Crema'),(133,16,'Fondant premium'),(134,16,'Vainilla natural'),(135,16,'Azúcar'),(136,16,'Mantequilla'),(137,17,'Chocolate oscuro'),(138,17,'Chocolate blanco'),(139,17,'Cocoa natural'),(140,17,'Harina'),(141,18,'Avellanas'),(142,18,'Chocolate ferrero'),(143,18,'Crema de cacao'),(144,18,'Harina'),(145,19,'Nutella'),(146,19,'Harina'),(147,19,'Huevos'),(148,19,'Azúcar'),(149,20,'Chocolate semi-amargo'),(150,20,'Nuez tostada'),(151,20,'Harina'),(152,20,'Crema'),(153,21,'Cocoa'),(154,21,'Mousse de chocolate'),(155,21,'Crema para batir'),(156,21,'Huevos'),(157,22,'Mango'),(158,22,'Crema fresca'),(159,22,'Harina'),(160,22,'Azúcar'),(161,23,'Duraznos frescos'),(162,23,'Crema'),(163,23,'Harina'),(164,23,'Huevos'),(165,24,'Kiwi'),(166,24,'Yogurt natural'),(167,24,'Harina'),(168,24,'Azúcar ligera'),(169,25,'Manzana'),(170,25,'Canela'),(171,25,'Harina'),(172,25,'Azúcar morena'),(173,26,'Uvas frescas'),(174,26,'Crema blanca'),(175,26,'Harina'),(176,26,'Azúcar');
/*!40000 ALTER TABLE `ingrediente` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pastel`
--

DROP TABLE IF EXISTS `pastel`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `pastel` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(50) NOT NULL,
  `Descripcion` varchar(200) DEFAULT NULL,
  `Precio` decimal(10,2) NOT NULL,
  `IdCategoria` int NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IdCategoria` (`IdCategoria`),
  CONSTRAINT `pastel_ibfk_1` FOREIGN KEY (`IdCategoria`) REFERENCES `categoria` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=27 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pastel`
--

LOCK TABLES `pastel` WRITE;
/*!40000 ALTER TABLE `pastel` DISABLE KEYS */;
INSERT INTO `pastel` VALUES (1,'Pastel de Chocolate Clásico','Delicioso pastel de chocolate con relleno de ganache y cobertura de buttercream.',450.00,4),(2,'Pastel de Fresas','Fresas frescas con crema batida natural, ideal para celebraciones.',380.00,5),(3,'Pastel Elegante para Bodas','Diseño sofisticado con decoración premium para eventos especiales.',850.00,3),(4,'Pastel de Vainilla Francesa','Vainilla premium con frutas rojas y textura suave.',420.00,2),(5,'Pastel de Zanahoria','Bizcocho especiado con nuez y cobertura de cream cheese.',390.00,2),(6,'Pastel de Limón','Refrescante pastel cítrico relleno de crema de limón y merengue.',360.00,5),(7,'Pastel Arcoíris','Bizcocho colorido con betún de vainilla.',410.00,2),(8,'Pastel Chispas de Colores','Pastel esponjoso con chispas y cobertura azucarada.',390.00,2),(9,'Pastel de Vainilla con Fondant','Diseño divertido hecho con fondant suave.',480.00,2),(10,'Pastel Confetti','Pastel suave con confetti horneado y crema batida.',430.00,2),(11,'Pastel Niño Dinosaurio','Decorado con temática infantil de dinosaurios.',520.00,2),(12,'Pastel Blanco Premium','Pastel clásico de boda con acabado elegante.',1200.00,3),(13,'Pastel Floral Rosas','Decorado con flores naturales y crema suave.',1400.00,3),(14,'Pastel Marmoleado Elegante','Diseño marmoleado ideal para eventos.',1550.00,3),(15,'Pastel Oro y Vainilla','Decoración dorada con vainilla francesa.',1600.00,3),(16,'Pastel de Nupcias Moderno','Diseño minimalista con detalles premium.',1700.00,3),(17,'Pastel Triple Chocolate','Chocolate oscuro, leche y blanco.',520.00,4),(18,'Pastel Ferrero','Inspirado en Ferrero Rocher con avellanas.',580.00,4),(19,'Pastel Nutella Deluxe','Relleno cremoso de Nutella.',560.00,4),(20,'Pastel Choco-Nuez','Delicioso chocolate con nuez tostada.',490.00,4),(21,'Pastel Mousse de Chocolate','Capa esponjosa con mousse suave.',530.00,4),(22,'Pastel Mango Tropical','Suave crema y trozos de mango natural.',430.00,5),(23,'Pastel Durazno Cremoso','Pastel con duraznos frescos.',420.00,5),(24,'Pastel Kiwi & Yogurt','Ligero, fresco y balanceado.',450.00,5),(25,'Pastel Manzana Canela','Manzana caramelizada con toque de canela.',440.00,5),(26,'Pastel Uva y Crema Blanca','Combinación ligera con uvas frescas.',460.00,5);
/*!40000 ALTER TABLE `pastel` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pedido`
--

DROP TABLE IF EXISTS `pedido`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `pedido` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `NombreCliente` varchar(100) DEFAULT NULL,
  `Telefono` varchar(20) DEFAULT NULL,
  `Correo` varchar(80) DEFAULT NULL,
  `Instrucciones` varchar(200) DEFAULT NULL,
  `Total` decimal(10,2) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pedido`
--

LOCK TABLES `pedido` WRITE;
/*!40000 ALTER TABLE `pedido` DISABLE KEYS */;
INSERT INTO `pedido` VALUES (3,'Jose ','8611351184','jgamez2704@gmail.com','Recogeré el día de mañana a las 5:00 pm ',1900.00),(4,'Queso','8611234566','queso@gmail.com','Recogeré a las 4:00 pm, en día martes ',470.00);
/*!40000 ALTER TABLE `pedido` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pedido_detalle`
--

DROP TABLE IF EXISTS `pedido_detalle`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `pedido_detalle` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `IdPedido` int NOT NULL,
  `IdPastel` int NOT NULL,
  `IdTamano` int NOT NULL,
  `Cantidad` int NOT NULL,
  `PrecioUnitario` decimal(10,2) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IdPedido` (`IdPedido`),
  KEY `IdPastel` (`IdPastel`),
  KEY `IdTamano` (`IdTamano`),
  CONSTRAINT `pedido_detalle_ibfk_1` FOREIGN KEY (`IdPedido`) REFERENCES `pedido` (`Id`),
  CONSTRAINT `pedido_detalle_ibfk_2` FOREIGN KEY (`IdPastel`) REFERENCES `pastel` (`Id`),
  CONSTRAINT `pedido_detalle_ibfk_3` FOREIGN KEY (`IdTamano`) REFERENCES `tamano_pastel` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pedido_detalle`
--

LOCK TABLES `pedido_detalle` WRITE;
/*!40000 ALTER TABLE `pedido_detalle` DISABLE KEYS */;
/*!40000 ALTER TABLE `pedido_detalle` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tamano_pastel`
--

DROP TABLE IF EXISTS `tamano_pastel`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tamano_pastel` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(50) NOT NULL,
  `Precio` decimal(10,2) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tamano_pastel`
--

LOCK TABLES `tamano_pastel` WRITE;
/*!40000 ALTER TABLE `tamano_pastel` DISABLE KEYS */;
INSERT INTO `tamano_pastel` VALUES (1,'Chico (8 porciones)',0.00),(2,'Mediano (12 porciones)',450.00),(3,'Grande (16 porciones)',650.00);
/*!40000 ALTER TABLE `tamano_pastel` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuarioadmin`
--

DROP TABLE IF EXISTS `usuarioadmin`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `usuarioadmin` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Nickname` varchar(60) NOT NULL,
  `Contrasena` varchar(255) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuarioadmin`
--

LOCK TABLES `usuarioadmin` WRITE;
/*!40000 ALTER TABLE `usuarioadmin` DISABLE KEYS */;
/*!40000 ALTER TABLE `usuarioadmin` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-12-11 14:51:05
