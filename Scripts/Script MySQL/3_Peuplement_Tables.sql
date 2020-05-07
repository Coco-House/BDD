-- insertion dans la table fournisseur

INSERT INTO `projet`.`fournisseur` (`idF`,`nomF`,`telF`) VALUES ('F100', 'Distram', '0124359927');
INSERT INTO `projet`.`fournisseur` (`idF`,`nomF`,`telF`) VALUES ('F200', 'Davigel', '0106149938');
INSERT INTO `projet`.`fournisseur` (`idF`,`nomF`,`telF`) VALUES ('F300', 'Agidra', '0136928534');
INSERT INTO `projet`.`fournisseur` (`idF`,`nomF`,`telF`) VALUES ('F400', 'MiamLand', '0126339604');
INSERT INTO `projet`.`fournisseur` (`idF`,`nomF`,`telF`) VALUES ('F500', 'TransGourmet', '0811656588');
INSERT INTO `projet`.`fournisseur` (`idF`,`nomF`,`telF`) VALUES ('F600', 'Berard', '0490715574');
INSERT INTO `projet`.`fournisseur` (`idF`,`nomF`,`telF`) VALUES ('F700', 'brake', '0142335164');
INSERT INTO `projet`.`fournisseur` (`idF`,`nomF`,`telF`) VALUES ('F800', 'PassionFroid', '0112204935');
INSERT INTO `projet`.`fournisseur` (`idF`,`nomF`,`telF`) VALUES ('F900', 'OpaDistribution', '0410499351');
INSERT INTO `projet`.`fournisseur` (`idF`,`nomF`,`telF`) VALUES ('F1000', 'Odestro SARL', '0139849491');
INSERT INTO `projet`.`fournisseur` (`idF`,`nomF`,`telF`) VALUES ('F1100', 'Buisson', '0111934843');
INSERT INTO `projet`.`fournisseur` (`idF`,`nomF`,`telF`) VALUES ('F1200', 'Les Menus du Monde', '0492548989');
INSERT INTO `projet`.`fournisseur` (`idF`,`nomF`,`telF`) VALUES ('F1300', 'Maïs Délice', '0446980970');
INSERT INTO `projet`.`fournisseur` (`idF`,`nomF`,`telF`) VALUES ('F1400', 'Le Delas', '0406387412');
INSERT INTO `projet`.`fournisseur` (`idF`,`nomF`,`telF`) VALUES ('F1500', 'Au Paradis des Papilles', '0159028434');

-- insertion dans la table produit

INSERT INTO `projet`.`produit` (`nomP`,`categorieP`,`unite`,`stockActuel`,`stockMin`,`stockMax`,`idF`) VALUES ('saumon', 'poisson', 'kg',10,3,20,'F200');


-- insertion dans la table client

INSERT INTO `projet`.`client` (`idC`,`nomC`,`prenomC`,`DateNaissance`,`age`,`adresse`,`sexe`,`email`,`password`,`telC`) VALUES ('C123456','DUPONT','Nicolas','2000-05-18',YEAR(CURDATE())-YEAR(`DateNaissance`),'25 Rue de la Republique, 75001, Paris','M','dupont.nicolas@gmail.com','Nicolas2000','0651249903');
INSERT INTO `projet`.`client` (`idC`,`nomC`,`prenomC`,`DateNaissance`,`age`,`adresse`,`sexe`,`email`,`password`,`telC`) VALUES ('C789987','MARTIN','Jeanne','1999-04-14',YEAR(CURDATE())-YEAR(`DateNaissance`),'42 rue de la Paix, 75001, Paris','F','martin.jeanne@gmail.com','Jeanne1999','0712456598');


-- insertion dans la table CdR

INSERT INTO `projet`.`cdr` (`idCdR`,`cook`,`idC`) VALUES ('CdR123321',40,'C123456');


-- insertion dans la table recette

INSERT INTO `projet`.`recette` (`idR`,`nomR`,`type`,`listeIngredients`,`descriptionR`,`prixR`,`remunerationCuisinier`,`idGratification`,`nbCook`,`idCdR`) VALUES ('R1','tiramisu','Dessert','oeufs;sucre;vanille;mascarpone;biscuits à la cuillère;café;cacao','Dessert italien',12,2,'GratR1',2,'CdR123321');

-- insertion dans la table cooking

INSERT INTO `projet`.`cooking` (`idCooking`) VALUES ('C00K1');
