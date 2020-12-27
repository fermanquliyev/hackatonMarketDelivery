package com.example.onlinemarketdelivery

import android.os.Bundle
import android.view.WindowManager
import androidx.appcompat.app.AppCompatActivity
import androidx.fragment.app.Fragment
import com.denzcoskun.imageslider.models.SlideModel
import com.example.onlinemarketdelivery.fragments.*
import kotlinx.android.synthetic.main.activity_bottom_navigation.*
import kotlinx.android.synthetic.main.fragment_home.*

class BottomNavigation : AppCompatActivity() {

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_bottom_navigation)

        makeCurrentFragment(HomeFragment())

        bottom_navigation.setOnNavigationItemSelectedListener {
            when(it.itemId){
                R.id.ic_home -> makeCurrentFragment(HomeFragment())
                R.id.ic_nearby -> makeCurrentFragment(NearbyFragment())
                R.id.ic_categories -> makeCurrentFragment(CategoryFragment())
                R.id.ic_virtual_cart -> makeCurrentFragment(CartFragment())
                R.id.ic_discount -> makeCurrentFragment(DiscountFragment())
            }
            true
        }
    }

    private fun makeCurrentFragment(frag: Fragment) {
        supportFragmentManager.beginTransaction().apply{
            replace(R.id.fl_wrapper, frag)
            commit()
        }
    }
}