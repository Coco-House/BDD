-- MySQL dump 10.13  Distrib 8.0.5, for Win64 (x86_64)
--
-- Host: localhost    Database: projet
-- ------------------------------------------------------
-- Server version	8.0.19

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
 SET NAMES utf8mb4 ;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Current Database: `projet`
--

CREATE DATABASE /*!32312 IF NOT EXISTS*/ `projet` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;

USE `projet`;

--
-- Table structure for table `cdr`
--

DROP TABLE IF EXISTS `cdr`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `cdr` (
  `idCdR` varchar(10) NOT NULL,
  `cook` int NOT NULL,
  `idC` varchar(10) NOT NULL,
  PRIMARY KEY (`idCdR`),
  KEY `idC` (`idC`),
  CONSTRAINT `cdr_ibfk_1` FOREIGN KEY (`idC`) REFERENCES `client` (`idC`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cdr`
--

LOCK TABLES `cdr` WRITE;
/*!40000 ALTER TABLE `cdr` DISABLE KEYS */;
INSERT INTO `cdr` VALUES ('CdR029384',46,'C187483'),('CdR102938',20,'C789987'),('CdR123321',40,'C123456'),('CdR241234',24,'C789987'),('CdR918274',9,'C198743');
/*!40000 ALTER TABLE `cdr` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `client`
--

DROP TABLE IF EXISTS `client`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `client` (
  `idC` varchar(10) NOT NULL,
  `nomC` varchar(20) NOT NULL,
  `prenomC` varchar(20) NOT NULL,
  `DateNaissance` date NOT NULL,
  `age` int NOT NULL,
  `adresse` varchar(50) NOT NULL,
  `sexe` char(1) NOT NULL,
  `email` varchar(30) NOT NULL,
  `password` varchar(30) NOT NULL,
  `telC` varchar(10) NOT NULL,
  PRIMARY KEY (`idC`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `client`
--

LOCK TABLES `client` WRITE;
/*!40000 ALTER TABLE `client` DISABLE KEYS */;
INSERT INTO `client` VALUES ('C019847','LABELLE','Viollette','1995-02-24',25,'80 rue Marguerite, 94300, Vincennes','F','viollette.labelle@gmail.com','viollettetropbelle','0753110854'),('C029834','FABRE','Frédéric','1983-08-31',36,'50 place du Jeu de Paume, 47000, Agen','M','frederic.fabre@outlook.com','FabreFrederic','0619830294'),('C123456','DUPONT','Nicolas','2000-05-18',19,'25 rue de la Republique, 75001, Paris','M','dupont.nicolas@gmail.com','Nicolas2000','0651249903'),('C187483','BERNARD','Virginie','1985-04-05',35,'19 boulevar Amiral Courbet, 44700, Orvault','F','virginieb@gmail.com','virginieB321','0701943895'),('C198743','GUERTIN','Nadine','1992-02-21',28,'18 rue du Château, 42100, Saint-Etienne','F','nadine.guertin@yahoo.fr','Nadine','0709142374'),('C429385','BEAUCHESNE','Thiery','1970-10-02',49,'12 rue Marie de Médicis, 06150, Cannes-La-Bocca','M','b.thiery@outlook.com','thierybg','0183472993'),('C437619','DEMANGE','Maxence','1992-11-20',27,'82 rue Sébastopol, 97230, Sainte-Marie','F','demange.maxence@outlook.com','demangemax','0619805832'),('C640593','QUINCY','Marceau','1989-07-13',30,'83 boulevard Bryas, 60100, Creil','M','quicy.m@gmail.com','MarceauESILV','0612540365'),('C789987','MARTIN','Jeanne','1999-04-14',21,'42 rue de la Paix, 75001, Paris','F','martin.jeanne@gmail.com','Jeanne1999','0712456598'),('C928502','DUMONT','Ambre','1994-10-22',25,'27 rue Adolphe Wurtz','F','ambredumont@gmail.com','ambredumont123','0785931948');
/*!40000 ALTER TABLE `client` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cooking`
--

DROP TABLE IF EXISTS `cooking`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `cooking` (
  `idCooking` varchar(10) NOT NULL,
  PRIMARY KEY (`idCooking`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cooking`
--

LOCK TABLES `cooking` WRITE;
/*!40000 ALTER TABLE `cooking` DISABLE KEYS */;
INSERT INTO `cooking` VALUES ('C00K1'),('C00K2'),('C00K3'),('C00K4'),('C00K5'),('C00K6'),('C00K7');
/*!40000 ALTER TABLE `cooking` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `fournisseur`
--

DROP TABLE IF EXISTS `fournisseur`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `fournisseur` (
  `idF` varchar(10) NOT NULL,
  `nomF` varchar(30) NOT NULL,
  `telF` varchar(10) NOT NULL,
  PRIMARY KEY (`idF`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `fournisseur`
--

LOCK TABLES `fournisseur` WRITE;
/*!40000 ALTER TABLE `fournisseur` DISABLE KEYS */;
INSERT INTO `fournisseur` VALUES ('F100','Distram','0124359927'),('F1000','Odestro SARL','0139849491'),('F1100','Buisson','0111934843'),('F1200','Les Menus du Monde','0492548989'),('F1300','Maïs Délice','0446980970'),('F1400','Le Delas','0406387412'),('F1500','Au Paradis des Papilles','0159028434'),('F1600','Légumes et fruits frais','0112548963'),('F200','Davigel','0106149938'),('F300','Agidra','0136928534'),('F400','MiamLand','0126339604'),('F500','TransGourmet','0811656588'),('F600','Berard','0490715574'),('F700','brake','0142335164'),('F800','PassionFroid','0112204935'),('F900','OpaDistribution','0410499351');
/*!40000 ALTER TABLE `fournisseur` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `produit`
--

DROP TABLE IF EXISTS `produit`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `produit` (
  `nomP` varchar(30) NOT NULL,
  `categorieP` varchar(30) NOT NULL,
  `unite` varchar(5) NOT NULL,
  `stockActuel` int NOT NULL,
  `stockMin` int NOT NULL,
  `stockMax` int NOT NULL,
  `idF` varchar(10) NOT NULL,
  PRIMARY KEY (`nomP`),
  KEY `idF` (`idF`),
  CONSTRAINT `produit_ibfk_1` FOREIGN KEY (`idF`) REFERENCES `fournisseur` (`idF`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `produit`
--

LOCK TABLES `produit` WRITE;
/*!40000 ALTER TABLE `produit` DISABLE KEYS */;
INSERT INTO `produit` VALUES ('ail','légume','unite',38,25,100,'F1600'),('basilic','légume','g',4700,1200,7000,'F1600'),('beurre','matières grasses','g',600,200,1000,'F300'),('biscuit à la cuillère','biscuit','unite',20,20,100,'F200'),('boeuf haché','aliment','g',13950,10000,50000,'F200'),('cacao','poudre','g',1550,1000,5000,'F200'),('café','boisson','cl',3500,2000,10000,'F200'),('carotte','légume','unite',57,35,150,'F1600'),('chocolat','produits sucrés','bar',240,100,600,'F100'),('concombre','légume','unite',390,300,800,'F1600'),('courgette','légume','kg',30,10,100,'F200'),('crème fraîche','matières grasses','cup',30,20,70,'F1200'),('eau','boisson','L',15,10,30,'F1100'),('farine','produits céréaliers','g',15000,10000,60000,'F900'),('fromage râpé','aliment','g',1040,1000,3000,'F200'),('gruyère râpé','fromage','g',5000,2000,10000,'F200'),('huile','huiles','tbsp',240,150,350,'F400'),('lait','boisson','L',25,10,40,'F1100'),('lardon','aliment','g',2000,400,3000,'F400'),('laurier','légume','tbsp',29,30,50,'F1600'),('levure','aliment','g',1200,800,3000,'F900'),('mascarpone','fromage','g',49700,5000,80000,'F200'),('muscade','épice','tbsp',21,20,90,'F500'),('oeuf','aliment','unite',220,150,500,'F200'),('oignon','légume','unite',55,30,110,'F1600'),('pâte brisée','préparations pour pâtisseries','g',6000,1000,8000,'F1200'),('pâte de lasagne','aliment','g',1480,2000,8000,'F1400'),('poivre','épice','g',1910,800,3000,'F500'),('poivron','légume','unite',320,250,650,'F1600'),('pomme','fruit','unite',270,200,650,'F1600'),('purée de tomate','sauce','tbsp',214,150,500,'F600'),('saumon','poisson','kg',10,3,20,'F200'),('sel','sel','g',29925,15000,60000,'F500'),('sucre','sucre','g',49760,10000,100000,'F200'),('thym','épice','tbsp',36,20,60,'F500'),('tomate','fruit','unite',450,300,800,'F1600'),('vanille','épice','unite',47,10,150,'F200'),('vinaigre','vinaigre','tbsp',210,120,320,'F400');
/*!40000 ALTER TABLE `produit` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `recette`
--

DROP TABLE IF EXISTS `recette`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `recette` (
  `idR` varchar(10) NOT NULL,
  `nomR` varchar(30) NOT NULL,
  `type` varchar(10) DEFAULT NULL,
  `listeIngredients` varchar(200) NOT NULL,
  `quantites` varchar(200) NOT NULL,
  `descriptionR` text NOT NULL,
  `prixR` int NOT NULL,
  `remunerationCuisinier` int NOT NULL,
  `nbCommandes` int NOT NULL,
  `idGratification` varchar(10) NOT NULL,
  `nbCook` int NOT NULL,
  `idCdR` varchar(10) NOT NULL,
  PRIMARY KEY (`idR`),
  KEY `idCdR` (`idCdR`),
  CONSTRAINT `recette_ibfk_1` FOREIGN KEY (`idCdR`) REFERENCES `cdr` (`idCdR`),
  CONSTRAINT `recette_chk_1` CHECK ((locate(_utf8mb4' ',`type`) = 0)),
  CONSTRAINT `recette_chk_2` CHECK ((`prixR` between 10 and 40))
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `recette`
--

LOCK TABLES `recette` WRITE;
/*!40000 ALTER TABLE `recette` DISABLE KEYS */;
INSERT INTO `recette` VALUES ('R1','Tiramisu','Dessert','oeuf;sucre;vanille;mascarpone;biscuit à la cuillère;café;cacao','4;80;1;100;10;500;150','Dessert italien',14,2,11,'GratR1',2,'CdR123321'),('R10','Fondant au chocolat','Dessert','chocolat;farine;sucre;oeuf;beurre','3;150;80;2;65','Gâteau au chocolat fondant',12,2,1,'GratR10',2,'CdR102938'),('R2','Flan de courgettes','Entrée','courgette;gruyère râpé;lait;oeuf;basilic','1.5;120;0.5;3;50','Entrée froide végétarienne sans gluten',16,2,0,'GratR2',2,'CdR918274'),('R3','Quiche lorraine','Plat','pâte brisée;lardon;beurre;oeuf;crème fraîche;lait;muscade;sel;poivre','300;500;120;4;2;0.3;3;10;15','Quiche lorraine en plat principal',20,2,3,'GratR3',2,'CdR918274'),('R4','Lasagnes à la bolognaise','Plat','pâte de lasagne;oignons;ail;carotte;boeuf haché;purée de tomate;eau;laurier;thym;basilic;muscade;fromage râpé;sel;poivre','340;3;4;1;350;12;0.2;2;2;100;3;200;25;30','Lasagnes italiennes',30,4,51,'GratR4',2,'CdR241234'),('R5','Pancake','Dessert','farine;sucre;oeufs;levure;beurre;sel;lait','400;250;8;50;150;20;1','Dessert rapide et végétarien',18,2,27,'GratR5',2,'CdR918274'),('R6','Cookie au chocolat','Dessert','beurre;oeuf;sucre;vanille;farine;chocolat;sel;levure','150;6;250;2;450;4;10;60','Dessert végétarien',30,2,34,'GratR6',2,'CdR029384'),('R7','Tarte aux pommes','Dessert','pâte brisée;pomme;sucre;beurre','300;5;200;100','Dessert normand rapide',12,2,5,'GratR7',10,'CdR029384'),('R8','Gaspacho','Entrée','tomate;poivron;concombre;oignon;ail;vinaigre;oeuf;basilic;huile;poivre;sel','5;3;2;3;5;3;2;35;5;40;30','Entrée végétarienne rapide et froide',18,2,12,'GratR8',2,'CdR102938'),('R9','Crêpe','Dessert','farine;sucre;oeuf;beurre;sel;lait;huile','300;240;6;100;10;0.7;3','Dessert rapide',16,2,24,'GratR9',2,'CdR102938');
/*!40000 ALTER TABLE `recette` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-05-08  8:57:32
