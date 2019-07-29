import React, { Component } from 'react';
import * as THREE from '../threejs/js/three';

import './ThreeContainer.css';

class ThreeContainer extends Component{

  componentDidMount(){
    const three = THREE;

    const scene = new THREE.Scene();

    const fov = 45;
    const aspect = window.innerWidth / window.innerHeight;
    // If aspect doesn't work, replace with " width / height "  
    // const width = window.innerWidth;
    // const height = window.innerHeight;
    const near = 0.1;
    const far = 1000;

    const camera = new THREE.PerspectiveCamera( fov, aspect, near, far );

    const renderer = new THREE.WebGLRenderer();
    renderer.setSize( window.innerWidith, window.innerHeight );
    document.body.appendChild( renderer.domElement );
    
    // logic goes here
    const update = () => {};

    // draw scene
    const render = () => {
      renderer.render( scene, camera );
    }

    //run game loop (update, render, repeat)
    const GameLoop = () => {
      requestAnimationFrame( GameLoop );

      update();
      render();
    };

    GameLoop();
  }

  render() {
      return(
        <div />
      )
  }
}
export default ThreeContainer
