create table category(
    idcategory INTEGER PRIMARY key IDENTITY,
    name varchar(50) not null UNIQUE, 
    description varchar (256) null, 
    condition bit DEFAULT(1)
);



CREATE TABLE article(
    idarticle integer PRIMARY KEY IDENTITY, 
    idcategory INTEGER not NULL,
    code VARCHAR(50) null,
    name VARCHAR(100) not null unique, 
    price_sale DECIMAL(11,2) not null,
    stock INTEGER NOT NULL, 
    description VARCHAR(256) null,
    condition BIT DEFAULT(1)
    FOREIGN KEY (idcategory) REFERENCES category(idcategory)

);


create table person (
  idperson integer PRIMARY KEY IDENTITY, 
  type_person VARCHAR(20) not null,
  name VARCHAR(100) not null,
  type_document varchar(20) null,
  num_document VARCHAR(20) null,
  address VARCHAR(70) null,
  phone VARCHAR(20) null,
  email  VARCHAR(50)
 
);


CREATE TABLE  role (
    idrole INTEGER primary KEY IDENTITY,
    name VARCHAR(30) not null,
    description VARCHAR(100) null,
    condition bit DEFAULT(1)
);

CREATE TABLE users(
    iduser integer PRIMARY KEY IDENTITY, 
    idrole INTEGER not NULL,
    name VARCHAR(100 ) not null,
    type_document VARCHAR(20) null,
    num_document VARCHAR(20) null,
    address varchar(70) null,
    phone VARCHAR(20) null,
    email VARCHAR(50) not null, 
    password_hash varbinary not null, 
    password_salt varbinary not null,
    condition bit DEFAULT(1),
    FOREIGN KEY(idrole) REFERENCES role (idrole)
);


create table entry(
    identry integer primary key identity, 
    idprovider INTEGER not null,
    iduser INTEGER not null,
    type_voucher VARCHAR(20) not null,
    num_voucher VARCHAR(10) not null, 
    date_time DATETIME not null,
    tax DECIMAL(4,2) not null,
    total DECIMAL(11,2) not NULl,
    status varchar(20) not null,
    FOREIGN KEY(idprovider) REFERENCES person(idperson),
    FOREIGN KEY(iduser) REFERENCES users(iduser)
);

CREATE TABLE detail_entry(
    iddetail_entry INTEGER PRIMARY KEY IDENTITY, 
    identry INTEGER not NULL,
    idarticle INTEGER not null,
    quantity INTEGER not null,
    price DECIMAL(11,2) not null
    FOREIGN KEY (identry) REFERENCES entry (identry) ON DELETE CASCADE,
    FOREIGN KEY (idarticle) REFERENCES article (idarticle)
);

create table sale (
    idsale integer primary key IDENTITY, 
    idclient  integer not null, 
    iduser INTEGER not NULL, 
    type_voucher VARCHAR(20) not null,
    serie_voucher VARCHAR(7) null,
    num_voucher VARCHAR(10) not null,
    date_time DATETIME not null, 
    tax DECIMAL (4,2) not null,
    total DECIMAL (11,2) not null,
    status VARCHAR(20) not null
    FOREIGN KEY (idclient) REFERENCES person (idperson),
    FOREIGN KEY (iduser) REFERENCES users (iduser)

);


create table datail_sale(
    iddatail_sale INTEGER PRIMARY KEY IDENTITY,
    idsale INTEGER not null,
    idarticle INTEGER not NULL,
    quantity INTEGER not NULL, 
    price DECIMAL(11,2) not null,
    discount DECIMAL(11,2) not null,
    FOREIGN KEY (idsale) REFERENCES sale(idsale) on DELETE CASCADE,
    FOREIGN KEY (idarticle) REFERENCES article(idarticle)
);