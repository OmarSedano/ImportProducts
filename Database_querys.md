# SQL Test Assignment

Attached is a mysqldump of a database to be used during the test.

Below are the questions for this test. Please enter a full, complete, working SQL statement under each question. We do not want the answer to the question. We want the SQL command to derive the answer. We will copy/paste these commands to test the validity of the answer.

**Example:**

_Q. Select all users_

- Please return at least first_name and last_name

SELECT first_name, last_name FROM users;


------

**— Test Starts Here —**

1. Select users whose id is either 3,2 or 4
- Please return at least: all user fields

SELECT * FROM users WHERE id IN (3,2,4);

2. Count how many basic and premium listings each active user has
- Please return at least: first_name, last_name, basic, premium


3. Show the same count as before but only if they have at least ONE premium listing
- Please return at least: first_name, last_name, basic, premium


4. How much revenue has each active vendor made in 2013
- Please return at least: first_name, last_name, currency, revenue

SELECT first_name, last_name, currency, SUM(CASE WHEN year(c.created) = 2013 THEN price ELSE 0 END) as revenue FROM users u
LEFT JOIN listings l
ON u.id = l.user_id 
LEFT JOIN clicks c
ON l.id = c.listing_id
WHERE u.status = 2 
group by u.id

5. Insert a new click for listing id 3, at $4.00
- Find out the id of this new click. Please return at least: id

INSERT INTO clicks
VALUES(NULL,3,4.00,'USD', now());
SELECT LAST_INSERT_ID();

6. Show listings that have not received a click in 2013
- Please return at least: listing_name

SELECT l.id, l.name as listing_name FROM listings l
left join (SELECT * FROM clicks WHERE year(created) = 2013) c
on c.listing_id = l.id
group by l.id
having sum(case when c.id is null then 0 else 1 end) = 0;


7. For each year show number of listings clicked and number of vendors who owned these listings
- Please return at least: date, total_listings_clicked, total_vendors_affected

SELECT year(c.created) as date, count(*) as total_listings_clicked, count(distinct(u.id)) as total_vendors_affected  FROM clicks c
left join listings l
on c.listing_id = l.id
left join users u
on u.id = l.user_id
where c.created is not null
group by year(c.created)


8. Return a comma separated string of listing names for all active vendors
- Please return at least: first_name, last_name, listing_names

SELECT u.first_name, u.last_name, GROUP_CONCAT(l.name ORDER BY l.name ASC SEPARATOR ',') listing_names FROM users u
left join listings l
on u.id = l.user_id
where u.status = 2
group by u.id;