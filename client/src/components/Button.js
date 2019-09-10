import React from 'react';
import {View, Text, TouchableOpacity, StyleSheet} from 'react-native';

const Button = ({title, style = {}, onPress}) => {
  return (
    <TouchableOpacity onPress={() => typeof onPress === 'function' && onPress()}>
      <View style={[styles.button, style]}>
        <Text style={styles.title}>{title}</Text>
      </View>
    </TouchableOpacity>
  );
};

export default Button;

const styles = {
  button: {
    alignSelf: 'stretch',
    backgroundColor: '#0275d8',
    margin: 10,
    padding: 15,
    borderRadius: 15,
  },
  title: {
    alignSelf: 'center',
    fontSize: 18,
    color: '#ffffff'
  },
};
