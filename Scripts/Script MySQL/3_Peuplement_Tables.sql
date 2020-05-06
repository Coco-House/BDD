-- insertion dans la table fournisseur

INSERT INTO `projet`.`fournisseur` (`idF`,`nomF`,`telF`) VALUES ('F100', 'Distram', '0124359927');
INSERT INTO `projet`.`fournisseur` (`idF`,`nomF`,`telF`) VALUES ('F200', 'Davigel', '0106149938');
INSERT INTO `projet`.`fournisseur` (`idF`,`nomF`,`telF`) VALUES ('F300', 'Agidra', '0136928534');
INSERT INTO `projet`.`fournisseur` (`idF`,`nomF`,`telF`) VALUES ('F400', 'MiamLand', '0126339604');

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