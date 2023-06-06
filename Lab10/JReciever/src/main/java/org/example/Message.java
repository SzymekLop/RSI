package org.example;
import com.fasterxml.jackson.annotation.JsonProperty;

import java.time.LocalDateTime;

public class Message {
    @JsonProperty("Time")
    private LocalDateTime time;
    @JsonProperty("Body")
    private String body;
    @JsonProperty("Value")
    private int value;

    @Override
    public String toString() {
        return "Message{" +
                "At: " + time +
                ", message='" + body + '\'' +
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

    public Message(LocalDateTime time, String message, int value) {
        this.time = time;
        this.body = message;
        this.value = value;
    }

    public LocalDateTime getTime() {
        return time;
    }

    public void setTime(LocalDateTime time) {
        this.time = time;
    }

    public int getValue() {
        return value;
    }

    public void setValue(int value) {
        this.value = value;
    }
}
