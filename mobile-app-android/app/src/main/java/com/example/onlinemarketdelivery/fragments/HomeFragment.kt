package com.example.onlinemarketdelivery.fragments

import android.os.Bundle
import androidx.fragment.app.Fragment
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.view.WindowManager
import com.denzcoskun.imageslider.models.SlideModel
import com.example.onlinemarketdelivery.R
import kotlinx.android.synthetic.main.fragment_home.*
import kotlinx.android.synthetic.main.fragment_home.view.*

class HomeFragment : Fragment() {

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)

    }

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View? {
        val view = inflater.inflate(R.layout.fragment_home, container, false)

        val slideModels = ArrayList<SlideModel>()
        slideModels.add(SlideModel(R.drawable.image1))
        slideModels.add(SlideModel(R.drawable.image2))
        slideModels.add(SlideModel(R.drawable.image3))
        slideModels.add(SlideModel(R.drawable.image4))
        slideModels.add(SlideModel(R.drawable.image5))
        view.slider?.setImageList(slideModels, true)

        return view
    }
}