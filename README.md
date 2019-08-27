# ApacheKafkaSample
Demo for implementation of Apache Kafka with producer and consumer

## Commands Used
Source: https://kafka.apache.org/quickstart

Zookeeper start

``` zkserver zkserver.config```

Kafka Server start

``` kafka-server-start.bat c:\Kafka\config\server.properties```

Creating topic

``` kafka-topic.bat --create --bootstrap-server localhost:9092 --replication-factor 1 --partitions 1 --topic test```
 

## Resources for this document

https://codenotfound.com/apache-kafka-download-installation.html

Version of Kafka & ZooKeeper 
https://www.apache.org/dyn/closer.cgi?path=/kafka/2.3.0/kafka_2.12-2.3.0.tgz


