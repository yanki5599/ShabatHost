use master;

declare varchar(25) guest


IF DB_ID('shabat') IS NOT NULL
BEGIN
    CREATE DATABASE [shabat];
END

use shabat;

IF NOT EXISTS(
SELECT
   *
   FROM
   INFORMATION_SCHEMA.TABLES
   WHERE
   TABLE_NAME = 'Guests'
 )
 BEGIN 
    
END;