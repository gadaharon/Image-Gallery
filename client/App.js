/**
 * Sample React Native App
 * https://github.com/facebook/react-native
 *
 * @format
 * @flow
 */

import React, {Fragment} from 'react';
import ImageGalleryScreen from './src/screens/ImageGalleryScreen';
import {StatusBar, SafeAreaView, StyleSheet } from 'react-native';
import Header from './src/components/Header';

const App = () => {
  return (
    <Fragment>
      <StatusBar barStyle="dark-content" />
      <Header title="גלרית תמונות" />
      <SafeAreaView style={styles.container}>
        <ImageGalleryScreen />
      </SafeAreaView>
    </Fragment>
  );
};

const styles = StyleSheet.create({
  container: {
    flex: 1,
  },
});

export default App;
