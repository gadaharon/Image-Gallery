import React from 'react';
import {View, Text, StyleSheet} from 'react-native';

const Header = ({title, style = {}}) => {
  return (
    <View style={[styles.header, style]}>
      <Text style={styles.title}>{title}</Text>
    </View>
  );
};

export default Header;

const styles = StyleSheet.create({
  header: {
    alignSelf: 'stretch',
    padding: 20,
    marginBottom: 10,
    backgroundColor: '#0275d8',
  },
  title: {
    fontSize: 20,
    color: '#ffffff',
  },
});
