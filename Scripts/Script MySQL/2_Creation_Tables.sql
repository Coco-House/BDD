USE projet;

CREATE TABLE projet.`fournisseur`
(
	`idF` VARCHAR(10) NOT NULL,
	`nomF` VARCHAR(20) NOT NULL,
	`telF` VARCHAR(10) NOT NULL,
	PRIMARY KEY (`idF`)
);

CREATE TABLE projet.`produit`
(
	`nomP` VARCHAR(20) NOT NULL,
    `categorieP` VARCHAR(20) NOT NULL,
    `unite` VARCHAR(5) NOT NULL,
    `stockActuel` INT NOT NULL,
    `stockMin` INT NOT NULL,
    `stockMax` INT NOT NULL,
    `idF` VARCHAR(10) NOT NULL,
	PRIMARY KEY (`nomP`),
    FOREIGN KEY (`idF`) REFERENCES `projet`.`fournisseur`(`idF`)
);

CREATE TABLE projet.`client`
(
	`idC` VARCHAR(10) NOT NULL,
	`nomC` VARCHAR(20) NOT NULL,
    `prenomC` VARCHAR(20) NOT NULL,
    `DateNaissance` DATE NOT NULL,
    `age` INT NOT NULL,
    `adresse` VARCHAR(50) NOT NULL,
    `sexe` CHAR(1) NOT NULL,
    `email` VARCHAR(30) NOT NULL,
    `password` VARCHAR(30) NOT NULL,
	`telC` VARCHAR(10)  NOT NULL,
	PRIMARY KEY (`idC`)
);

CREATE TABLE projet.`cdr`
(
	`idCdR` VARCHAR(10) NOT NULL,
    `cook` INT NOT NULL,
    `idC` VARCHAR(10) NOT NULL,
	PRIMARY KEY (`idCdR`),
    FOREIGN KEY (`idC`) REFERENCES `projet`.`client`(`idC`)
);

CREATE TABLE projet.`recette`
(
	`idR` VARCHAR(10) NOT NULL,
	`nomR` VARCHAR(20) NOT NULL,
    `type` VARCHAR(10) CHECK(LOCATE(' ',`type`)=0) ,
    `listeIngredients` VARCHAR(100) NOT NULL, -- c'est un string de nom de produits separes par un ;
    `descriptionR` TEXT(256) NOT NULL,
	`prixR` INT NOT NULL CHECK(`prixR` BETWEEN 10 and 40 ),
    `remunerationCuisinier` INT NOT NULL,
    `idGratification` VARCHAR(10) NOT NULL,
    `nbCook` INT NOT NULL,
    `idCdR` VARCHAR(10) NOT NULL,
	PRIMARY KEY (`idR`),
    FOREIGN KEY (`idCdR`) REFERENCES `projet`.`cdr`(`idCdR`)
);


CREATE TABLE projet.`cooking`
(
	`idCooking` VARCHAR(10) NOT NULL,
	PRIMARY KEY (`idCooking`)
);
