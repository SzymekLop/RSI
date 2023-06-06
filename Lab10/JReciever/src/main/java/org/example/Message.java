package org.example;
import com.fasterxml.jackson.annotation.JsonFormat;
import com.fasterxml.jackson.annotation.JsonProperty;
import com.fasterxml.jackson.databind.annotation.JsonDeserialize;
import com.fasterxml.jackson.databind.annotation.JsonSerialize;
import org.example.Json.LocalTimeDeserializer;
import org.example.Json.LocalTimeSerializer;

import java.time.LocalTime;

public class Message {
    @JsonProperty("Time")
    @JsonSerialize(using = LocalTimeSerializer.class)
    @JsonDeserialize(using = LocalTimeDeserializer.class)
    private LocalTime time;
    @JsonProperty("Body")
    private String body;
    @JsonProperty("Value")
    private int value;

    @Override
    public String toString() {
        return "Message{" +
                "At: " + time +
                ", body='" + body + '\'' +
                ", value=" + value +
                '}';
    }

    public String getBody() {
        return body;
    }

    public void setBody(String body) {
        this.body = body;
    }

    public Message(){

    }

    public Message(LocalTime time, String message, int value) {
        this.time = time;
        this.body = message;
        this.value = value;
    }

    public LocalTime getTime() {
        return time;
    }

    public void setTime(LocalTime time) {
        this.time = time;
    }

    public int getValue() {
        return value;
    }

    public void setValue(int value) {
        this.value = value;
    }

}
