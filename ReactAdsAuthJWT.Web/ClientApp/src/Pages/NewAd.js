import axios from 'axios';
import React, { useState } from 'react';
import { useHistory } from 'react-router-dom';
import getAxios from '../AuthAxios';

const NewAd = () => {
    const [formData, setFormData] = useState({ number: '', description: '' });
    const history = useHistory();

    const onTextChange = (e) => {
        setFormData({ ...formData, [e.target.name]: e.target.value });
    }

    const onSubmitClick = async (e) => {
        e.preventDefault();
        await getAxios().post('/api/ads/newad', formData);
        history.push('/');
    }
    const { number, description } = formData;

    return (<div className="container">
        <main role="main" className="pb-3">
            <div className="row">
                <div className="col-md-6 offset-md-3">
                    <h2>New Ad</h2>
                </div>
            </div>

            <div className="row">
                <div className="col-md-6 offset-md-3 jumbotron">
                    <form onSubmit={onSubmitClick}>
                        <div className="row">
                            <div className="col-md-12">
                                <input type="text" placeholder="Phone Number" onChange={onTextChange} value={number} className="form-control" name="number" />
                            </div>
                        </div>
                        <br />
                        <textarea name="description" className="form-control" onChange={onTextChange} value={description} rows="10" placeholder="Description"></textarea>
                        <button className="btn btn-primary">Submit</button>
                    </form>
                </div>
            </div>
        </main>
    </div>

    )
}
export default NewAd;