package com.example.apptecair;

import android.content.Context;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;

import androidx.annotation.Nullable;

public class Database extends SQLiteOpenHelper {

    public static final String DATABASE = "TECAirDB";

    // Customer table
    public static final String TABLE_CUSTOMERS = "customer";
    public static final String CUSTOMERID = "customerid";
    public static final String NAMECUSTOMER = "namecustomer";
    public static final String LASTNAMECUSTOMER = "lastnamecustomer";
    public static final String PASSCUSTOMER = "passcustomer";
    public static final String EMAIL = "email";
    public static final String PHONE = "phone";
    public static final String STUDENTID = "studentid";
    public static final String UNIVERSITY = "university";
    public static final String MILES = "miles";

    // Workers table
    public static final String TABLE_WORKERS = "Worker";
    public static final String WORKERID = "workerid";
    public static final String NAMEWORKER = "nameworker";
    public static final String LASTNAMEWORKER = "lastnameworker";
    public static final String PASSWORKER = "passworker";

    // Plane table
    public static final String TABLE_PLANE = "Plane";
    public static final String PLANEID = "planeid";
    public static final String MODEL = "model";
    public static final String PASSENGERCAP = "passengercap";
    public static final String BAGCAP = "bagcap";

    // Bag table
    public static final String TABLE_BAGS = "bag";
    public static final String BAGID = "bagid";
    public static final String WEIGHT = "weight";
    public static final String COLOR = "color";
    public static final String PRICE = "price";
    public static final String CUSTOMERID_BAG = "customerid";
    public static final String FLIGHTID_BAG = "flightid";

    // Flight table
    public static final String TABLE_FLIGHTS = "flight";
    public static final String FLIGHTID = "flightid";
    public static final String BAGQUANTITY = "bagquantity";
    public static final String USERQUANTITY = "userquantity";
    public static final String GATE = "gate";
    public static final String DEPARTURE = "departure";
    public static final String ARRIVAL = "arrival";
    public static final String ORIGIN = "origin";
    public static final String DESTINATION = "destination";
    public static final String STOPS = "stops";
    public static final String STATUS = "status";
    public static final String PRICE_FLIGHT = "price";
    public static final String DISCOUNT = "discount";
    public static final String WORKERID_FLIGHT = "workerid";
    public static final String PLANEID_FLIGHT = "planeid";

    // Customer in flight table
    public static final String TABLE_CUSTOMERINFLIGHT = "customerinflight";
    public static final String SEATNUM = "seatnum";
    public static final String CUSTOMERID_CIF = "customerid";
    public static final String FLIGHTID_CIF = "flightid";


    public Database(@Nullable Context context) {
        super(context, DATABASE, null, 1);
    }

    @Override
    public void onCreate(SQLiteDatabase db) {
        // Create customer table
        db.execSQL("CREATE TABLE " + TABLE_CUSTOMERS + "(" + CUSTOMERID + " INTEGER PRIMARY KEY, " + NAMECUSTOMER + " TEXT NOT NULL, "
                + LASTNAMECUSTOMER + " TEXT NOT NULL, " + PASSCUSTOMER + " TEXT NOT NULL, " + EMAIL + " TEXT NOT NULL UNIQUE, " +
                PHONE + " INTEGER NOT NULL, " + STUDENTID + " INTEGER UNIQUE, " + UNIVERSITY + " TEXT, " + MILES + " INTEGER DEFAULT 0)");

        // Create worker table
        db.execSQL("CREATE TABLE " + TABLE_WORKERS + "(" + WORKERID + " INTEGER PRIMARY KEY, " + NAMEWORKER + " TEXT NOT NULL, "
                + LASTNAMEWORKER + " TEXT NOT NULL, " + PASSWORKER + " TEXT NOT NULL)");

        // Create plane table
        db.execSQL("CREATE TABLE " + TABLE_PLANE + "(" + PLANEID + " TEXT PRIMARY KEY, " + MODEL + " TEXT NOT NULL, "
                + PASSENGERCAP + " INTEGER NOT NULL, " + BAGCAP + " INTEGER NOT NULL)");

        // Create flight table
        db.execSQL("CREATE TABLE " + TABLE_FLIGHTS + "(" + FLIGHTID + " TEXT PRIMARY KEY, " + BAGQUANTITY + " INTEGER DEFAULT 0, "
                + USERQUANTITY + " INTEGER DEFAULT 0, " + GATE + " INTEGER NOT NULL, " + DEPARTURE + " TIMESTAMP NOT NULL, " +
                ARRIVAL + " TIMESTAMP NOT NULL, " + ORIGIN + " TEXT NOT NULL, " + DESTINATION + " TEXT NOT NULL, "
                + STOPS + " TEXT, " + STATUS + " TEXT, " + PRICE_FLIGHT + " INTEGER, " + DISCOUNT + " INTEGER DEFAULT 0, " +
                "FOREIGN KEY("+WORKERID_FLIGHT+") REFERENCES "+TABLE_WORKERS+"("+WORKERID+"), " +
                "FOREIGN KEY("+PLANEID_FLIGHT+") REFERENCES "+TABLE_PLANE+"("+PLANEID+"))");

        // Create bag table
        db.execSQL("CREATE TABLE " + TABLE_BAGS + "(" + BAGID + " TEXT PRIMARY KEY, " + WEIGHT + " INTEGER, " + COLOR +
                " TEXT, " + PRICE + " INTEGER, " + "FOREIGN KEY("+CUSTOMERID_BAG+") REFERENCES "+TABLE_CUSTOMERS+"("+CUSTOMERID+"), " +
                "FOREIGN KEY("+FLIGHTID_BAG+") REFERENCES "+TABLE_FLIGHTS+"("+FLIGHTID+"))");

        // Create customer in flight table
        db.execSQL("CREATE TABLE " + TABLE_CUSTOMERINFLIGHT + "(" + SEATNUM + " TEXT, " + "FOREIGN KEY("+CUSTOMERID_CIF+") " +
                "REFERENCES "+TABLE_CUSTOMERS+"("+CUSTOMERID+"), " + "FOREIGN KEY("+FLIGHTID_CIF+") " +
                "REFERENCES "+TABLE_FLIGHTS+"("+FLIGHTID+"), " + "PRIMARY KEY (" + CUSTOMERID_CIF + ", " + FLIGHTID_CIF + "))");
    }

    @Override
    public void onUpgrade(SQLiteDatabase sqLiteDatabase, int i, int i1) {

    }
}
