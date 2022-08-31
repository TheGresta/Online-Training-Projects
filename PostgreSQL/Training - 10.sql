SELECT country, city.city FROM city
LEFT JOIN country ON  city.country_id = country.country_id
ORDER BY country, city.city;

SELECT payment.payment_id, first_name, last_name FROM customer
RIGHT JOIN payment ON  payment.customer_id = customer.customer_id
ORDER BY payment.payment_id, first_name, last_name;

SELECT rental.rental_id, first_name, last_name FROM customer
FULL JOIN rental ON  rental.customer_id = customer.customer_id
ORDER BY rental.rental_id, first_name, last_name;