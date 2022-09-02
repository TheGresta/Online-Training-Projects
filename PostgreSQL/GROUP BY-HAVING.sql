/*
1.) film tablosunda bulunan filmleri rating değerlerine göre gruplayınız.
2.) film tablosunda bulunan filmleri replacement_cost sütununa göre grupladığımızda film sayısı 50 den fazla olan 
replacement_cost değerini ve karşılık gelen film sayısını sıralayınız.
*/
SELECT rating, COUNT(DISTINCT title) FROM film
GROUP BY rating;

SELECT replacement_cost, COUNT(*) FROM film
GROUP BY replacement_cost
HAVING COUNT(*) > 50;

SELECT store_id, COUNT(*) FROM customer
GROUP BY store_id;

SELECT country_id, COUNT(*) FROM city
GROUP BY country_id
ORDER BY COUNT(*) DESC
LIMIT 1;