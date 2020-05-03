-- insertion dans la table fournisseur

INSERT INTO `projet`.`fournisseur` (`idF`,`nomF`,`telF`) VALUES ('FX482', 'Distram', 0124359927);
INSERT INTO `projet`.`fournisseur` (`idF`,`nomF`,`telF`) VALUES ('FU155', 'Davigel', 0106149938);
INSERT INTO `projet`.`fournisseur` (`idF`,`nomF`,`telF`) VALUES ('FX751', 'Agidra', 0136928534);
INSERT INTO `projet`.`fournisseur` (`idF`,`nomF`,`telF`) VALUES ('FP330', 'MiamLand', 0126339604);

-- insertion dans la table produit

INSERT INTO `projet`.`produit` (`nomP`,`categorieP`,`quantite`,`stockAct`,`stockMin`,`stockMax`,`idF`) VALUES ('saumon', 'poisson', 12,10,3,20,'FU155');


-- insertion dans la table client

INSERT INTO `projet`.`client` (`idC`,`nomC`,`telC`) VALUES (15234,'Bernard',0651249903);


-- insertion dans la table CdR

INSERT INTO `projet`.`cdr` (`idCdR`,`cook`,`idC`) VALUES (14,300,15234);


-- insertion dans la table recette

INSERT INTO `projet`.`recette` (`idR`,`nomR`,`listeIngredients`,`descriptionR`,`prixR`,`remunerationCuisinier`,`idCdR`) VALUES (1,'tiramisu','oeufs,sucre,vanille,mascarpone,biscuits à la cuillère,café,cacao','dessert',4.99,5,14);


-- insertion dans la table pointcook

INSERT INTO `projet`.`pointcook` (`idPointCook`,`nbCook`,`idCdR`) VALUES (42,300,14);

-- insertion dans la table cooking

INSERT INTO `projet`.`cooking` (`idCooking`) VALUES (65);