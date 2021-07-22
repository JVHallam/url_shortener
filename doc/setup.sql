
--Check if exists before creating
CREATE TABLE URLS ( 
	ID_column INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	url VARCHAR(MAX) not null
);

INSERT INTO URLS VALUES ( 'https://www.google.com' );

SELECT TOP 1 * FROM URLS
