import React, { Component, Fragment } from 'react'
import ReactPlayer from 'react-player'
import { Media,Button } from 'reactstrap'
import ClipLoader from "react-spinners/ClipLoader";



export default class extends Component {
  state = {
    loading: true,
    track: {}
  }

  componentDidMount() {
    const { id } = this.props.match.params

    fetch(`https://localhost:44383/search/Lookup/${id}`)
      .then(res => res.json())
      .then(json => this.setState({ track: json.detailsRes[0],loading: false }))
  }

  goBack = () => {
    this.props.history.goBack()
  }

  render() {
    const {
      trackName,
      artistName,
      trackPrice,
      currency,
      artworkUrl100,
      previewUrl
    } = this.state.track

    return (
      <Fragment>
        <ClipLoader
                size={400}
                color={"#123abc"}
                loading={this.state.loading}
        />
        <h1>{trackName}</h1>
        <Media object src={artworkUrl100} alt={trackName} />
        <hr />
        <h2> <u><b>Artist:</b></u> {artistName}</h2>
        <h2> <u><b>Track Name:</b></u> {trackName}</h2> 
        <h2> <u><b>Price:</b></u> {trackPrice} {currency}</h2> 
        <h3>Play Demo:</h3>
        <ReactPlayer controls url={previewUrl} /> 
        <hr />
        <Button color="primary" onClick={this.goBack}>Go Back</Button>
      </Fragment>
    )
  }
}
