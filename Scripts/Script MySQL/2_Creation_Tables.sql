USE `projet`;

CREATE TABLE `projet`.`fournisseur`
(
	`idF` VARCHAR(10) NOT NULL,
	`nomF` VARCHAR(20) NOT NULL,
	`telF` INT NOT NULL,
	PRIMARY KEY (`idF`)
);

CREATE TABLE `projet`.`produit`
(
	`nomP` VARCHAR(20) NOT NULL,
    `categorieP` VARCHAR(20) NOT NULL,
	`quantite` INT NOT NULL,
    `stockActuel` INT NOT NULL,
    `stockMin` INT NOT NULL,
    `stockMax` INT NOT NULL,
    `idF` VARCHAR(10) NOT NULL,
	PRIMARY KEY (`nomP`),
    FOREIGN KEY (`idF`) REFERENCES `projet`.`fournisseur`(`idF`)
);

CREATE TABLE `projet`.`client`
(
	`idC` INT NOT NULL,
	`nomC` VARCHAR(20) NOT NULL,
	`telC` INT NOT NULL,
	PRIMARY KEY (`idC`)
);

CREATE TABLE `projet`.`cdr`
(
	`idCdR` INT NOT NULL,
    `cook` INT NOT NULL,
    `idC` INT NOT NULL,
	PRIMARY KEY (`idCdR`),
    FOREIGN KEY (`idC`) REFERENCES `projet`.`client`(`idC`)
);

CREATE TABLE `projet`.`recette`
(
	`idR` INT NOT NULL,
	`nomR` VARCHAR(20) NOT NULL,
    `listeIngredients` VARCHAR(100) NOT NULL,
    `descriptionR` VARCHAR(100) NOT NULL,
	`prixR` FLOAT NOT NULL,
    `remunerationCuisinier` FLOAT NOT NULL,
    `idCdR` INT NOT NULL,
	PRIMARY KEY (`idR`),
    FOREIGN KEY (`idCdR`) REFERENCES `projet`.`cdr`(`idCdR`)
);


CREATE TABLE `projet`.`pointcook`
(
	`idPointCook` INT NOT NULL,
    `nbCook` INT NOT NULL,
    `idCdR` INT NOT NULL,
	PRIMARY KEY (`idPointCook`),
    FOREIGN KEY (`idCdR`) REFERENCES `projet`.`cdr`(`idCdR`)
);

CREATE TABLE `projet`.`cooking`
(
	`idCooking` INT NOT NULL,
	PRIMARY KEY (`idCooking`)
);