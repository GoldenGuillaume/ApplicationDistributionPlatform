CREATE DATABASE apps_distribution_platform
    WITH 
    OWNER = postgres
    ENCODING = 'UTF8'
    TABLESPACE = tb_platform
    CONNECTION LIMIT = -1;

COMMENT ON DATABASE apps_distribution_platform
    IS 'Database for storing applications library imported';


CREATE TABLE applications (
	id INTEGER PRIMARY KEY GENERATED ALWAYS AS IDENTITY,
	creation_date TIMESTAMP NOT NULL DEFAULT NOW(),
	application_name VARCHAR(70) NOT NULL,
	thumbnail BYTEA NOT NULL,
	source_files BYTEA NOT NULL
);

COMMENT ON TABLE applications IS 'Table containing application saved.'