CREATE TABLE employee (
	id SERIAL PRIMARY KEY,
	name VARCHAR(50) NOT NULL,
	birthday DATE,
	email VARCHAR(100)
);


UPDATE employee
SET name = 'Name Changed'
WHERE name ~~ 'K%' AND id BETWEEN 20 AND 30;

DELETE FROM employee
WHERE birthday BETWEEN '01.01.1990' AND '01.01.2000' AND name ~~* 'D%'
RETURNING *;

DELETE FROM employee
WHERE name ~~* '%e' AND name ~~* 'd%' AND id BETWEEN 40 AND 50
RETURNING *;

DELETE FROM employee
WHERE (email ~~* '%u' OR email ~~* 'a%') AND birthday > '01.01.2000'
RETURNING *

DELETE FROM employee
WHERE id > 45
RETURNING *;

DELETE FROM employee
WHERE email ~~* 'tc___%'
RETURNING *;

insert into employee (id, name, birthday, email) values (1, 'Tadio Cleyne', '1/16/1985', 'tcleyne0@squarespace.com');
insert into employee (id, name, birthday, email) values (2, 'Wally Shurey', '5/5/1994', 'wshurey1@latimes.com');
insert into employee (id, name, birthday, email) values (3, 'Hermy Tabart', '6/27/2005', 'htabart2@dagondesign.com');
insert into employee (id, name, birthday, email) values (4, 'Padraic Bisiker', '5/9/1991', 'pbisiker3@goo.ne.jp');
insert into employee (id, name, birthday, email) values (5, 'Alfonso Sisson', '4/2/1999', 'asisson4@chicagotribune.com');
insert into employee (id, name, birthday, email) values (6, 'Bessie Lamkin', '10/29/1997', 'blamkin5@thetimes.co.uk');
insert into employee (id, name, birthday, email) values (7, 'Ermin Fright', '6/20/2005', 'efright6@sbwire.com');
insert into employee (id, name, birthday, email) values (8, 'Carlin Vogl', '4/18/1998', 'cvogl7@mail.ru');
insert into employee (id, name, birthday, email) values (9, 'Cris Rackstraw', '4/2/2002', 'crackstraw8@usnews.com');
insert into employee (id, name, birthday, email) values (10, 'Katy Slater', '2/12/1994', 'kslater9@reddit.com');
insert into employee (id, name, birthday, email) values (11, 'Indira Freer', '6/22/2009', 'ifreera@google.ru');
insert into employee (id, name, birthday, email) values (12, 'Deanna Chree', '12/17/1991', 'dchreeb@sohu.com');
insert into employee (id, name, birthday, email) values (13, 'Bartolomeo Cabera', '1/30/1990', 'bcaberac@uol.com.br');
insert into employee (id, name, birthday, email) values (14, 'Lionello Causer', '9/28/2002', 'lcauserd@flavors.me');
insert into employee (id, name, birthday, email) values (15, 'Brigitta Dunkirk', '4/26/1986', 'bdunkirke@arstechnica.com');
insert into employee (id, name, birthday, email) values (16, 'Cthrine Northrop', '8/11/2001', 'cnorthropf@soundcloud.com');
insert into employee (id, name, birthday, email) values (17, 'Ferne Zavittieri', '11/11/1994', 'fzavittierig@merriam-webster.com');
insert into employee (id, name, birthday, email) values (18, 'Kippy Theaker', '3/25/1999', 'ktheakerh@blogger.com');
insert into employee (id, name, birthday, email) values (19, 'Lucho Hendrik', '8/31/1999', 'lhendriki@csmonitor.com');
insert into employee (id, name, birthday, email) values (20, 'Kala Ryott', '5/30/2004', 'kryottj@topsy.com');
insert into employee (id, name, birthday, email) values (21, 'Lyman Potell', '9/28/1988', 'lpotellk@joomla.org');
insert into employee (id, name, birthday, email) values (22, 'Jordon Darth', '3/28/1989', 'jdarthl@auda.org.au');
insert into employee (id, name, birthday, email) values (23, 'Retha Hindenberger', '1/10/2007', 'rhindenbergerm@mapquest.com');
insert into employee (id, name, birthday, email) values (24, 'Paolo Hudspeth', '5/2/1995', 'phudspethn@ox.ac.uk');
insert into employee (id, name, birthday, email) values (25, 'Artus Vittori', '12/30/1993', 'avittorio@chronoengine.com');
insert into employee (id, name, birthday, email) values (26, 'Christal Lillywhite', '1/31/1996', 'clillywhitep@squidoo.com');
insert into employee (id, name, birthday, email) values (27, 'Meggi Dmtrovic', '1/7/1994', 'mdmtrovicq@eventbrite.com');
insert into employee (id, name, birthday, email) values (28, 'Nicolis Stendell', '12/9/2000', 'nstendellr@sciencedirect.com');
insert into employee (id, name, birthday, email) values (29, 'Kim Baldam', '8/8/2000', 'kbaldams@apache.org');
insert into employee (id, name, birthday, email) values (30, 'Welsh Pert', '9/20/2005', 'wpertt@amazon.co.jp');
insert into employee (id, name, birthday, email) values (31, 'Lewiss Fullager', '7/23/1994', 'lfullageru@parallels.com');
insert into employee (id, name, birthday, email) values (32, 'Gabie Prattin', '8/31/2001', 'gprattinv@typepad.com');
insert into employee (id, name, birthday, email) values (33, 'Gerri Simononsky', '12/8/2009', 'gsimononskyw@bing.com');
insert into employee (id, name, birthday, email) values (34, 'Sabra Aldrich', '6/10/1988', 'saldrichx@webnode.com');
insert into employee (id, name, birthday, email) values (35, 'Abraham Oswick', '3/5/2006', 'aoswicky@flickr.com');
insert into employee (id, name, birthday, email) values (36, 'Shelby Ambresin', '2/3/2007', 'sambresinz@squidoo.com');
insert into employee (id, name, birthday, email) values (37, 'Kassi Southern', '5/19/1995', 'ksouthern10@yandex.ru');
insert into employee (id, name, birthday, email) values (38, 'Flint MacKniely', '11/19/2006', 'fmackniely11@berkeley.edu');
insert into employee (id, name, birthday, email) values (39, 'Gawen Couroy', '12/30/1987', 'gcouroy12@nba.com');
insert into employee (id, name, birthday, email) values (40, 'Gabrielle Zanre', '10/10/1996', 'gzanre13@tumblr.com');
insert into employee (id, name, birthday, email) values (41, 'Frans Spragg', '10/30/1986', 'fspragg14@google.fr');
insert into employee (id, name, birthday, email) values (42, 'Davine Frift', '3/28/1992', 'dfrift15@mapquest.com');
insert into employee (id, name, birthday, email) values (43, 'Charla Danelut', '3/7/1988', 'cdanelut16@cdbaby.com');
insert into employee (id, name, birthday, email) values (44, 'Basia Heathcoat', '11/12/2005', 'bheathcoat17@myspace.com');
insert into employee (id, name, birthday, email) values (45, 'Ashil Yesichev', '2/11/1987', 'ayesichev18@guardian.co.uk');
insert into employee (id, name, birthday, email) values (46, 'Debby Van Halle', '10/20/2002', 'dvan19@eepurl.com');
insert into employee (id, name, birthday, email) values (47, 'Lilly Smalecombe', '8/7/1988', 'lsmalecombe1a@sciencedirect.com');
insert into employee (id, name, birthday, email) values (48, 'Yvon Rastrick', '3/22/2006', 'yrastrick1b@china.com.cn');
insert into employee (id, name, birthday, email) values (49, 'Rockwell Urlin', '1/17/2006', 'rurlin1c@weebly.com');
insert into employee (id, name, birthday, email) values (50, 'Rosanna Allsworth', '1/13/1994', 'rallsworth1d@china.com.cn');

