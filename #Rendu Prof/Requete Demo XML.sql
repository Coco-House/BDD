use projet;

SELECT nomP, stockActuel, stockMin, stockMax FROM produit WHERE stockActuel < stockMin;