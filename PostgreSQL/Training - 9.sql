SELECT country, city.city FROM country
JOIN city ON city.country_id = country.country_id
ORDER BY country ASC, city.city ASC;

SELECT first_name, last_name, payment.payment_id FROM customer
JOIN payment ON  customer.customer_id = payment.customer_id
ORDER BY first_name, last_name, payment.payment_id;

SELECT first_name, last_name, rental.rental_id FROM customer
JOIN rental ON  customer.customer_id = rental.customer_id
ORDER BY first_name, last_name, rental.rental_id;