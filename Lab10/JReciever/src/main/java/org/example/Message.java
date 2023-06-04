package org.example;
import com.fasterxml.jackson.annotation.JsonProperty;

import java.time.LocalDateTime;

public class Message {
    @JsonProperty("time")
    private LocalDateTime time;
    @JsonProperty("message")
    private String message;
    @JsonProperty("value")
    private int value;

    @Override
    public String toString() {
        return "Message{" +
                "At: " + time +
                ", message='" + message + '\'' +
                ", value=" + value +
                '}';
    }

    public String getMessage() {
        return message;
    }

    public void setMessage(String message) {
        this.message = message;
    }

    public Message(LocalDateTime time, String message, int value) {
        this.time = time;
        this.message = message;
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
