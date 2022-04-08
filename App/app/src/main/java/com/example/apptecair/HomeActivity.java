package com.example.apptecair;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;

/**
 * Class that represents the main activity of the app, the welcome page
 */
public class HomeActivity extends AppCompatActivity {

    Button signInBtn, signUpBtn;

    /**
     * The activity is initialized here, and its layout file is set
     * @param savedInstanceState a Bundle that contains the data the activity most recently
     * supplied if the activity is being re-initialized after previously being shut down.
     */
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_home);

        final Database db = new Database (HomeActivity.this);

        // All layout widgets are referenced
        signInBtn = findViewById(R.id.btnSignIn);
        signUpBtn = findViewById(R.id.btnSignUp);

        // Sets actions for the sign in button
        signInBtn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                // Starts the new log in activity
                Intent intent = new Intent(getApplicationContext(), LogInActivity.class);
                startActivity(intent);
            }
        });
    }
}