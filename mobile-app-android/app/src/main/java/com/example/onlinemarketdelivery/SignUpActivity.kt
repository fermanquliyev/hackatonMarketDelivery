package com.example.onlinemarketdelivery

import android.app.Activity
import android.content.Intent
import android.os.Bundle
import android.util.Log
import android.view.View
import android.widget.Toast
import com.example.onlinemarketdelivery.api.DeliveryService
import com.example.onlinemarketdelivery.api.ServiceBuilder
import com.example.onlinemarketdelivery.api.models.RegisterModel
import com.example.onlinemarketdelivery.api.models.RegisterResult
import kotlinx.android.synthetic.main.activity_main.*
import kotlinx.android.synthetic.main.activity_main.tvHead
import kotlinx.android.synthetic.main.activity_sign_up.*
import okhttp3.OkHttpClient
import okhttp3.Request
import retrofit2.Call
import retrofit2.Callback
import retrofit2.Response


class SignUpActivity : Activity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_sign_up)



        /*val request = ServiceBuilder.buildService(DeliveryService::class.java)
        val call = request.register(RegisterModel(
                "amir",
                "amirnamazov3@gmail.com",
                "amira_mirAZ1",
                "delivery",
        ))

        call.enqueue(object : Callback<RegisterResult> {
            override fun onResponse(call: Call<RegisterResult>, response: Response<RegisterResult>) {
                if (response.isSuccessful) {
                    Log.d("Test", "onResponse: " + response.body()?.tenantId)
                }
            }

            override fun onFailure(call: Call<RegisterResult>, t: Throwable) {
                Toast.makeText(this@SignUpActivity, "${t.message}", Toast.LENGTH_SHORT).show()
            }
        })*/
    }

    fun signIn(v: View){
        finish()
        startActivity(Intent(this@SignUpActivity, MainActivity::class.java))
    }
}