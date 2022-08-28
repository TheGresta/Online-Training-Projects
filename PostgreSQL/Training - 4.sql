SELECT DISTINCT replacement_cost FROM film;

SELECT COUNT(DISTINCT replacement_cost) FROM film;

SELECT COUNT(*) FROM film
WHERE title ~~ 'T%' AND rating = 'G';

SELECT COUNT(*) FROM country
WHERE country ~~ '_____';

SELECT COUNT(*) FROM city
WHERE city ~~* '%R';
