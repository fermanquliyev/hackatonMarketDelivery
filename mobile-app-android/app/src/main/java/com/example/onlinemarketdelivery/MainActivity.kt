package com.example.onlinemarketdelivery

import android.app.Activity
import android.content.Intent
import android.os.Bundle
import android.view.View
import kotlinx.android.synthetic.main.activity_main.*

class MainActivity : Activity() {

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)
    }

    fun registration(v: View){
        finish()
        startActivity(Intent(this@MainActivity, SignUpActivity :: class.java))
    }

    fun signIn(v: View){
        finish()
        startActivity(Intent(this@MainActivity, BottomNavigation :: class.java))
    }
}