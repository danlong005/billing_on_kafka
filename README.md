# Billing On Kafka

# SQL to setup the tables
```
create table subscriptions (
	id bigint, 
	amount_due decimal(15,2),
	due_day integer,
	paid_to timestamp,
	primary key (id)
);

create table general_ledger (
	id bigint,
	subscription_id bigint,
	paid_at timestamp,
	amount_paid decimal(15,2),
	primary key (id)
);


create table comments (
	id bigint,
	subscription_id bigint,
	written_at timestamp,
	message varchar(255),
	primary key(id)
);

insert into subscriptions values
  (1, 9.99, 23, current_timestamp), 
  (2, 10.00, 23, current_timestamp), 
  (3, 99.01, 23, current_timestamp);

```