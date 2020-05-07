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

INSERT INTO `projet`.`produit` (`nomP`,`categorieP`,`unite`,`stockActuel`,`stockMin`,`stockMax`,`idF`) VALUES ('oeuf','aliment','unite',80,10,100,'F200');
INSERT INTO `projet`.`produit` (`nomP`,`categorieP`,`unite`,`stockActuel`,`stockMin`,`stockMax`,`idF`) VALUES ('sucre','sucre','g',50000,10000,100000,'F200');
INSERT INTO `projet`.`produit` (`nomP`,`categorieP`,`unite`,`stockActuel`,`stockMin`,`stockMax`,`idF`) VALUES ('vanille','épice','unite',10,50,150,'F200');
INSERT INTO `projet`.`produit` (`nomP`,`categorieP`,`unite`,`stockActuel`,`stockMin`,`stockMax`,`idF`) VALUES ('mascarpone','fromage','g',50000,5000,80000,'F200');
INSERT INTO `projet`.`produit` (`nomP`,`categorieP`,`unite`,`stockActuel`,`stockMin`,`stockMax`,`idF`) VALUES ('biscuit à la cuillère','biscuit','unite',50,20,100,'F200');
INSERT INTO `projet`.`produit` (`nomP`,`categorieP`,`unite`,`stockActuel`,`stockMin`,`stockMax`,`idF`) VALUES ('café','boisson','cl',5000,2000,10000,'F200');
INSERT INTO `projet`.`produit` (`nomP`,`categorieP`,`unite`,`stockActuel`,`stockMin`,`stockMax`,`idF`) VALUES ('cacao','cocaine','g',2000,1000,5000,'F200');
INSERT INTO `projet`.`produit` (`nomP`,`categorieP`,`unite`,`stockActuel`,`stockMin`,`stockMax`,`idF`) VALUES ('courgette','légume','kg',30,10,100,'F200');
INSERT INTO `projet`.`produit` (`nomP`,`categorieP`,`unite`,`stockActuel`,`stockMin`,`stockMax`,`idF`) VALUES ('gruyère râpé','fromage','g',5000,2000,10000,'F200');
INSERT INTO `projet`.`produit` (`nomP`,`categorieP`,`unite`,`stockActuel`,`stockMin`,`stockMax`,`idF`) VALUES ('lait','boisson','kg',10,3,20,'F200');
INSERT INTO `projet`.`produit` (`nomP`,`categorieP`,`unite`,`stockActuel`,`stockMin`,`stockMax`,`idF`) VALUES ('saumon','poisson','kg',10,3,20,'F200');
INSERT INTO `projet`.`produit` (`nomP`,`categorieP`,`unite`,`stockActuel`,`stockMin`,`stockMax`,`idF`) VALUES ('saumon','poisson','kg',10,3,20,'F200');


-- insertion dans la table client

INSERT INTO `projet`.`client` (`idC`,`nomC`,`prenomC`,`DateNaissance`,`age`,`adresse`,`sexe`,`email`,`password`,`telC`) VALUES ('C123456','DUPONT','Nicolas','2000-05-18',YEAR(CURDATE())-YEAR(`DateNaissance`),'25 rue de la Republique, 75001, Paris','M','dupont.nicolas@gmail.com','Nicolas2000','0651249903');
INSERT INTO `projet`.`client` (`idC`,`nomC`,`prenomC`,`DateNaissance`,`age`,`adresse`,`sexe`,`email`,`password`,`telC`) VALUES ('C789987','MARTIN','Jeanne','1999-04-14',YEAR(CURDATE())-YEAR(`DateNaissance`),'42 rue de la Paix, 75001, Paris','F','martin.jeanne@gmail.com','Jeanne1999','0712456598');
INSERT INTO `projet`.`client` (`idC`,`nomC`,`prenomC`,`DateNaissance`,`age`,`adresse`,`sexe`,`email`,`password`,`telC`) VALUES ('C429385','BEAUCHESNE','Thiery','1970-10-02',YEAR(CURDATE())-YEAR(`DateNaissance`),'12 rue Marie de Médicis, 06150, Cannes-La-Bocca','M','b.thiery@outlook.com','thierybg','0183472993');
INSERT INTO `projet`.`client` (`idC`,`nomC`,`prenomC`,`DateNaissance`,`age`,`adresse`,`sexe`,`email`,`password`,`telC`) VALUES ('C640593','QUINCY','Marceau','1989-07-13',YEAR(CURDATE())-YEAR(`DateNaissance`),'83 boulevard Bryas, 60100, Creil','M','quicy.m@gmail.com','MarceauESILV','0612540365');
INSERT INTO `projet`.`client` (`idC`,`nomC`,`prenomC`,`DateNaissance`,`age`,`adresse`,`sexe`,`email`,`password`,`telC`) VALUES ('C198743','GUERTIN','Nadine','1992-02-21',YEAR(CURDATE())-YEAR(`DateNaissance`),'18 rue du Château, 42100, Saint-Etienne','F','nadine.guertin@yahoo.fr','Nadine','0709142374');
INSERT INTO `projet`.`client` (`idC`,`nomC`,`prenomC`,`DateNaissance`,`age`,`adresse`,`sexe`,`email`,`password`,`telC`) VALUES ('C019847','LABELLE','Viollette','1995-02-24',YEAR(CURDATE())-YEAR(`DateNaissance`),'80 rue Marguerite, 94300, Vincennes','F','viollette.labelle@gmail.com','viollettetropbelle','0753110854');
INSERT INTO `projet`.`client` (`idC`,`nomC`,`prenomC`,`DateNaissance`,`age`,`adresse`,`sexe`,`email`,`password`,`telC`) VALUES ('C928502','DUMONT','Ambre','1994-10-22',YEAR(CURDATE())-YEAR(`DateNaissance`),'27 rue Adolphe Wurtz','F','ambredumont@gmail.com','ambredumont123','0785931948');
INSERT INTO `projet`.`client` (`idC`,`nomC`,`prenomC`,`DateNaissance`,`age`,`adresse`,`sexe`,`email`,`password`,`telC`) VALUES ('C187483','BERNARD','Virginie','1985-04-05',YEAR(CURDATE())-YEAR(`DateNaissance`),'19 boulevar Amiral Courbet, 44700, Orvault','F','virginieb@gmail.com','virginieB321','0701943895');
INSERT INTO `projet`.`client` (`idC`,`nomC`,`prenomC`,`DateNaissance`,`age`,`adresse`,`sexe`,`email`,`password`,`telC`) VALUES ('C029834','FABRE','Frédéric','1983-08-31',YEAR(CURDATE())-YEAR(`DateNaissance`),'50 place du Jeu de Paume, 47000, Agen','M','frederic.fabre@outlook.com','FabreFrederic','0619830294');
INSERT INTO `projet`.`client` (`idC`,`nomC`,`prenomC`,`DateNaissance`,`age`,`adresse`,`sexe`,`email`,`password`,`telC`) VALUES ('C437619','DEMANGE','Maxence','1992-11-20',YEAR(CURDATE())-YEAR(`DateNaissance`),'82 rue Sébastopol, 97230, Sainte-Marie','F','demange.maxence@outlook.com','demangemax','0619805832');


-- insertion dans la table CdR

INSERT INTO `projet`.`cdr` (`idCdR`,`cook`,`idC`) VALUES ('CdR123321',40,'C123456');
INSERT INTO `projet`.`cdr` (`idCdR`,`cook`,`idC`) VALUES ('CdR241234',24,'C789987');
INSERT INTO `projet`.`cdr` (`idCdR`,`cook`,`idC`) VALUES ('CdR029384',46,'C187483');
INSERT INTO `projet`.`cdr` (`idCdR`,`cook`,`idC`) VALUES ('CdR102938',20,'C789987');
INSERT INTO `projet`.`cdr` (`idCdR`,`cook`,`idC`) VALUES ('CdR918274',120,'C198743');


-- insertion dans la table recette

INSERT INTO `projet`.`recette` (`idR`,`nomR`,`type`,`listeIngredients`,`descriptionR`,`prixR`,`remunerationCuisinier`,`idGratification`,`nbCook`,`idCdR`) VALUES ('R1','Tiramisu','Dessert','oeuf;sucre;vanille;mascarpone;biscuit à la cuillère;café;cacao','Dessert italien',12,2,'GratR1',2,'CdR123321');
INSERT INTO `projet`.`recette` (`idR`,`nomR`,`type`,`listeIngredients`,`descriptionR`,`prixR`,`remunerationCuisinier`,`idGratification`,`nbCook`,`idCdR`) VALUES ('R2','Flan de courgettes','Entrée','courgette;gruyère râpé;lait;oeuf;basilic','Entrée froide végétarienne sans gluten',16,2,'GratR2',2,'CdR918274');
INSERT INTO `projet`.`recette` (`idR`,`nomR`,`type`,`listeIngredients`,`descriptionR`,`prixR`,`remunerationCuisinier`,`idGratification`,`nbCook`,`idCdR`) VALUES ('R3','Quiche lorraine','Plat','pâte brisée;lardon;beurre;oeuf;crème fraîche;lait;muscade;sel;poivre','Quiche lorraine en plat principal',20,2,'GratR3',2,'CdR918274');
INSERT INTO `projet`.`recette` (`idR`,`nomR`,`type`,`listeIngredients`,`descriptionR`,`prixR`,`remunerationCuisinier`,`idGratification`,`nbCook`,`idCdR`) VALUES ('R4','Lasagnes à la bolognaise','Plat','pâte de lasagne;oignons;ail;carotte;boeuf haché;purée de tomate;eau;laurier;thym;basilic;muscade;fromage râpé;sel;poivre','Lasagnes italiennes',25,2,'GratR4',2,'CdR241234');
INSERT INTO `projet`.`recette` (`idR`,`nomR`,`type`,`listeIngredients`,`descriptionR`,`prixR`,`remunerationCuisinier`,`idGratification`,`nbCook`,`idCdR`) VALUES ('R5','Pancake','Dessert','farine;sucre;oeufs;levure;beurre;sel;lait','Dessert rapide et végétarien',8,2,'GratR5',2,'CdR918274');
INSERT INTO `projet`.`recette` (`idR`,`nomR`,`type`,`listeIngredients`,`descriptionR`,`prixR`,`remunerationCuisinier`,`idGratification`,`nbCook`,`idCdR`) VALUES ('R6','Cookie au chocolat','Dessert','beurre;oeuf;sucre;vanille;farine;chocolat;sel;levure','Dessert végétarien',4,2,'GratR6',2,'CdR029384');
INSERT INTO `projet`.`recette` (`idR`,`nomR`,`type`,`listeIngredients`,`descriptionR`,`prixR`,`remunerationCuisinier`,`idGratification`,`nbCook`,`idCdR`) VALUES ('R7','Tarte aux pommes','Dessert','pâte brisée;pomme;sucre;beurre','Dessert normand rapide',12,2,'GratR7',2,'CdR029384');
INSERT INTO `projet`.`recette` (`idR`,`nomR`,`type`,`listeIngredients`,`descriptionR`,`prixR`,`remunerationCuisinier`,`idGratification`,`nbCook`,`idCdR`) VALUES ('R8','Gaspacho','Entrée','tomate;poivron;concombre;oignon;ail;vinaigre;oeuf;basilic;huile;poivre;sel','Entrée végétarienne rapide et froide',8,2,'GratR8',2,'CdR102938');
INSERT INTO `projet`.`recette` (`idR`,`nomR`,`type`,`listeIngredients`,`descriptionR`,`prixR`,`remunerationCuisinier`,`idGratification`,`nbCook`,`idCdR`) VALUES ('R9','Crêpe','Dessert','farine;sucre;oeuf;beurre;sel;lait;huile','Dessert rapide',6,2,'GratR9',2,'CdR102938');
INSERT INTO `projet`.`recette` (`idR`,`nomR`,`type`,`listeIngredients`,`descriptionR`,`prixR`,`remunerationCuisinier`,`idGratification`,`nbCook`,`idCdR`) VALUES ('R10','Fondant au chocolat','Dessert','chocolat;farine;sucre;oeuf;beurre','Gâteau au chocolat fondant',12,2,'GratR10',2,'CdR102938');

-- insertion dans la table cooking

INSERT INTO `projet`.`cooking` (`idCooking`) VALUES ('C00K1');
INSERT INTO `projet`.`cooking` (`idCooking`) VALUES ('C00K2');
INSERT INTO `projet`.`cooking` (`idCooking`) VALUES ('C00K3');
INSERT INTO `projet`.`cooking` (`idCooking`) VALUES ('C00K4');
INSERT INTO `projet`.`cooking` (`idCooking`) VALUES ('C00K5');
INSERT INTO `projet`.`cooking` (`idCooking`) VALUES ('C00K6');
INSERT INTO `projet`.`cooking` (`idCooking`) VALUES ('C00K7');
