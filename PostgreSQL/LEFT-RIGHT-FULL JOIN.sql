/*
1.) city tablosu ile country tablosunda bulunan şehir (city) ve ülke (country) isimlerini birlikte görebileceğimiz LEFT JOIN sorgusunu yazınız.
2.) customer tablosu ile payment tablosunda bulunan payment_id ile customer tablosundaki first_name ve last_name isimlerini birlikte görebileceğimiz RIGHT JOIN sorgusunu yazınız.
3.) customer tablosu ile rental tablosunda bulunan rental_id ile customer tablosundaki first_name ve last_name isimlerini birlikte görebileceğimiz FULL JOIN sorgusunu yazınız.
*/
SELECT country, city.city FROM city
LEFT JOIN country ON  city.country_id = country.country_id
ORDER BY country, city.city;

SELECT payment.payment_id, first_name, last_name FROM customer
RIGHT JOIN payment ON  payment.customer_id = customer.customer_id
ORDER BY payment.payment_id, first_name, last_name;

SELECT rental.rental_id, first_name, last_name FROM customer
FULL JOIN rental ON  rental.customer_id = customer.customer_id
ORDER BY rental.rental_id, first_name, last_name;