# SqlStreamStoreDemos
In this project, we wish to explore SqlStreamStore. EventStore is a type of database in which you can store events. The need for such a type of database came due to the technique of event sourcing. There are databases that could store events, such as EventStore. SqlStreamStore is a nuget library that could be used in C# based projects. This library provides a way to convert database such as SqlServer, PostgreSQL as event store.

## Event sourcing
Event sourcing is a pattern where the state of its entities are stores as events. These events are replayed from the begining to get to the current state of its entities.

### What is a stream
Stream is something where events could be store. The order of the events in the stream is preserved. There are consistency checks applied in a stream

### What is a Message
Message (or event)is that is finally stored 

### Creating a StreamStore

### Creating a stream

### Creating a stream and adding messages to it

### Appending to an existing stream store

### Listing all the stream names

### 
