# .NET MySQL Example

## Database Table Definitions

### users
```mysql
create table users
(
    id       int primary key auto_increment,
    username text,
    email    varchar(320) not null unique,
    password text
);
```
