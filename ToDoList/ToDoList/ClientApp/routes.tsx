import * as React from 'react';
import { Route } from 'react-router-dom';
import { Layout } from './components/Layout';
import { ToDoList } from './components/ToDoList';

export const routes = <Layout>
    <Route exact path='/' component={ToDoList} />
</Layout>;
