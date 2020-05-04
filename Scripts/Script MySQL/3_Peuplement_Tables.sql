-- insertion dans la table fournisseur

INSERT INTO `projet`.`fournisseur` (`idF`,`nomF`,`telF`) VALUES ('F100', 'Distram', '0124359927');
INSERT INTO `projet`.`fournisseur` (`idF`,`nomF`,`telF`) VALUES ('F200', 'Davigel', '0106149938');
INSERT INTO `projet`.`fournisseur` (`idF`,`nomF`,`telF`) VALUES ('F300', 'Agidra', '0136928534');
INSERT INTO `projet`.`fournisseur` (`idF`,`nomF`,`telF`) VALUES ('F400', 'MiamLand', '0126339604');

-- insertion dans la table produit

INSERT INTO `projet`.`produit` (`nomP`,`categorieP`,`unite`,`stockActuel`,`stockMin`,`stockMax`,`idF`) VALUES ('saumon', 'poisson', 'kg',10,3,20,'F200');


-- insertion dans la table client

INSERT INTO `projet`.`client` (`idC`,`nomC`,`telC`) VALUES ('C1','Bernard','0651249903');


-- insertion dans la table CdR

INSERT INTO `projet`.`cdr` (`idCdR`,`cook`,`idC`) VALUES ('CdR1',40,'C1');


-- insertion dans la table recette

INSERT INTO `projet`.`recette` (`idR`,`nomR`,`type`,`listeIngredients`,`descriptionR`,`prixR`,`remunerationCuisinier`,`idGratification`,`nbCook`,`idCdR`) VALUES ('R1','tiramisu','Dessert','oeufs;sucre;vanille;mascarpone;biscuits à la cuillère;café;cacao','Dessert italien',12,2,'GratR1',2,'CdR1');

-- insertion dans la table cooking

INSERT INTO `projet`.`cooking` (`idCooking`) VALUES ('C00K1');