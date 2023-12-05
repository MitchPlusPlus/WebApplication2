CREATE TABLE projects (
	id INT NOT NULL PRIMARY KEY IDENTITY,
	projectName VARCHAR(100) NOT NULL,
	email VARCHAR(150) NOT NULL UNIQUE,
	phone VARCHAR(20) NULL,
	address VARCHAR(100) NULL,
	created_at DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP
);

INSERT INTO projects (projectName, email, phone, address)
VALUES
('proj one', 'pr_one_em@test.com', '5161234561111', 'New York, USA'),
('proj two', 'pr_two_em@test.com', '5161234562222', 'New York, USA')