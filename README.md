# Billing On Kafka

# Notes
Kafka can function as a pub/sub queue or a shared message queue. Default is to function as a
pub/sub queue. However, you can change that by having the consumers of the topic to share
a group id. This changes the function to a shared message queue. The messages are split out
between the different partitions. The partitions are allocated as evenly as possible over the 
consumers within the group.

We can alter a topic to have more partitions if neccessary. 

# SQL to setup the tables
```
create table subscriptions (
	id bigint, 
	amount_due decimal(15,2),
	due_day integer,
	paid_to timestamp,
	charger varchar(50),
	approval_callback varchar(50),
	declined_callback varchar(50),
	timeout_callback varchar(50),
	primary key (id)
);

create table general_ledger (
	id bigint,
	subscription_id bigint,
	paid_at timestamp,
	amount_paid decimal(15,2),
	primary key (id)
);

create table subscription_retries (
	id bigint, 
	subscription_id bigint,
	next_try_at timestamp,
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
  (1, 9.99, 23, current_timestamp, 'fake', 'simple', 'simple', ''), 
  (2, 10.00, 23, current_timestamp, 'fake', 'simple', 'simple', ''), 
  (3, 99.01, 23, current_timestamp, 'fake', 'simple', 'simple', '');


kafka-topics --create --topic billing --bootstrap-server localhost:9092
kafka-topics --create --topic decline_simple --bootstrap-server localhost:9092
kafka-topics --create --topic approval_simple --bootstrap-server localhost:9092

```
