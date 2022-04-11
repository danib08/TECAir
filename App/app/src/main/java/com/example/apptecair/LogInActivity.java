package com.example.apptecair;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

/**
 * Class that represents the log in activity
 */
public class LogInActivity extends AppCompatActivity {

    EditText idText, passText, nameText, lastNameText;
    Button signInBtn;

    /**
     * The activity is initialized here, and its layout file is set
     * @param savedInstanceState a Bundle that contains the data the activity most recently
     * supplied if the activity is being re-initialized after previously being shut down.
     */
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.sign_in);

        // All layout widgets are referenced
        idText = findViewById(R.id.editTextIdIn);
        passText = findViewById(R.id.editTextPassIn);
        signInBtn = findViewById(R.id.sendSignIn);

        nameText = findViewById(R.id.editTextName);
        lastNameText = findViewById(R.id.editTextLastName);

        // TODO: id sea numerico
        signInBtn.setOnClickListener(view -> {
            String id = idText.getText().toString();
            String password = passText.getText().toString();
            String name = nameText.getText().toString();
            String lastName = lastNameText.getText().toString();

            Database myDB = new Database(LogInActivity.this);
            myDB.addWorker(id.trim(),name.trim(),lastName.trim(),password.trim());
        });

    }
}