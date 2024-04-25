# kafka-dotnet


list topic
kafka-topics.sh --list --bootstrap-server localhost:9092

create topic
kafka-topics.sh --create --bootstrap-server localhost:9092 --replication-factor 1 --partitions 1 --topic tp-test


describe topic
kafka-topics.sh --describe --bootstrap-server localhost:9092 --topic tp-test


alter topic
kafka-topics.sh --alter --bootstrap-server localhost:9092 --topic tp-test --partitions 2


alter config topic
kafka-configs.sh --bootstrap-server localhost:9092 --alter --entity-type topics --entity-name tp-test --add-config retention.ms=1000


delete config topic
kafka-topics.sh --bootstrap-server localhost:9092 --delete --topic  tp-test


produce message
kafka-console-producer.sh --bootstrap-server localhost:9092 --topic tp-test


produce message with key (to sort)
kafka-console-producer.sh --bootstrap-server localhost:9092 --topic tp-test --property parse.key=true --property key.separator=;


consume messages from topic
kafka-console-consumer.sh --bootstrap-server localhost:9092 --topic tp-test --from-beginning


consume messages from topic with key
kafka-console-consumer.sh --bootstrap-server localhost:9092 --topic first_topic --from-beginning --property parse.key=true --property key.separator=;