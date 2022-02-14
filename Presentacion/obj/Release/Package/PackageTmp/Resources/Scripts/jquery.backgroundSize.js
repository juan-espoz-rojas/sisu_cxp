


<!DOCTYPE html>
<html>
  <head prefix="og: http://ogp.me/ns# fb: http://ogp.me/ns/fb# githubog: http://ogp.me/ns/fb/githubog#">
    <meta charset='utf-8'>
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
        <title>louisremi/jquery.backgroundSize.js · GitHub</title>
    <link rel="search" type="application/opensearchdescription+xml" href="/opensearch.xml" title="GitHub" />
    <link rel="fluid-icon" href="https://github.com/fluidicon.png" title="GitHub" />
    <link rel="apple-touch-icon" sizes="57x57" href="/apple-touch-icon-114.png" />
    <link rel="apple-touch-icon" sizes="114x114" href="/apple-touch-icon-114.png" />
    <link rel="apple-touch-icon" sizes="72x72" href="/apple-touch-icon-144.png" />
    <link rel="apple-touch-icon" sizes="144x144" href="/apple-touch-icon-144.png" />
    <link rel="logo" type="image/svg" href="https://github-media-downloads.s3.amazonaws.com/github-logo.svg" />
    <meta property="og:image" content="https://github.global.ssl.fastly.net/images/modules/logos_page/Octocat.png">
    <meta name="hostname" content="github-fe125-cp1-prd.iad.github.net">
    <meta name="ruby" content="ruby 1.9.3p194-tcs-github-tcmalloc (2012-05-25, TCS patched 2012-05-27, GitHub v1.0.36) [x86_64-linux]">
    <link rel="assets" href="https://github.global.ssl.fastly.net/">
    <link rel="xhr-socket" href="/_sockets" />
    
    


    <meta name="msapplication-TileImage" content="/windows-tile.png" />
    <meta name="msapplication-TileColor" content="#ffffff" />
    <meta name="selected-link" value="repo_source" data-pjax-transient />
    <meta content="collector.githubapp.com" name="octolytics-host" /><meta content="github" name="octolytics-app-id" /><meta content="36034fb7-ff3e-416f-92e2-d9e0c46aa750" name="octolytics-dimension-request_id" />
    

    
    
    <link rel="icon" type="image/x-icon" href="/favicon.ico" />

    <meta content="authenticity_token" name="csrf-param" />
<meta content="ibYFYXFFJDLn53UlbIz6HKLicDnKvT1wbvud4Zhvj2Q=" name="csrf-token" />

    <link href="https://github.global.ssl.fastly.net/assets/github-8d13b140cf7e2873c4dd1e0f589136f0e71bd381.css" media="all" rel="stylesheet" type="text/css" />
    <link href="https://github.global.ssl.fastly.net/assets/github2-d75c750a6b14571dc070b6570d9224acd7b6795e.css" media="all" rel="stylesheet" type="text/css" />
    


      <script src="https://github.global.ssl.fastly.net/assets/frameworks-f86a2975a82dceee28e5afe598d1ebbfd7109d79.js" type="text/javascript"></script>
      <script src="https://github.global.ssl.fastly.net/assets/github-5289a6d6f7dbb5c517007827e10db51fd3ea0251.js" type="text/javascript"></script>
      
      <meta http-equiv="x-pjax-version" content="119d1d5ab0189c49025edd294a6b79f2">

        <meta property="og:title" content="jquery.backgroundSize.js"/>
  <meta property="og:type" content="githubog:gitrepository"/>
  <meta property="og:url" content="https://github.com/louisremi/jquery.backgroundSize.js"/>
  <meta property="og:image" content="https://github.global.ssl.fastly.net/images/gravatars/gravatar-user-420.png"/>
  <meta property="og:site_name" content="GitHub"/>
  <meta property="og:description" content="jquery.backgroundSize.js - DEPRECATED, please use its successor: background-size polyfill"/>

  <meta name="description" content="jquery.backgroundSize.js - DEPRECATED, please use its successor: background-size polyfill" />

  <meta content="39374" name="octolytics-dimension-user_id" /><meta content="louisremi" name="octolytics-dimension-user_login" /><meta content="4004586" name="octolytics-dimension-repository_id" /><meta content="louisremi/jquery.backgroundSize.js" name="octolytics-dimension-repository_nwo" /><meta content="true" name="octolytics-dimension-repository_public" /><meta content="false" name="octolytics-dimension-repository_is_fork" /><meta content="4004586" name="octolytics-dimension-repository_network_root_id" /><meta content="louisremi/jquery.backgroundSize.js" name="octolytics-dimension-repository_network_root_nwo" />
  <link href="https://github.com/louisremi/jquery.backgroundSize.js/commits/master.atom" rel="alternate" title="Recent Commits to jquery.backgroundSize.js:master" type="application/atom+xml" />

  </head>


  <body class="logged_out  env-production windows vis-public">
    <div class="wrapper">
      
      
      


      
      <div class="header header-logged-out">
  <div class="container clearfix">

    <a class="header-logo-wordmark" href="https://github.com/">
      <span class="mega-octicon octicon-logo-github"></span>
    </a>

    <div class="header-actions">
        <a class="button primary" href="/signup">Sign up</a>
      <a class="button" href="/login?return_to=%2Flouisremi%2Fjquery.backgroundSize.js">Sign in</a>
    </div>

    <div class="command-bar js-command-bar  in-repository">

      <ul class="top-nav">
          <li class="explore"><a href="/explore">Explore</a></li>
        <li class="features"><a href="/features">Features</a></li>
          <li class="enterprise"><a href="https://enterprise.github.com/">Enterprise</a></li>
          <li class="blog"><a href="/blog">Blog</a></li>
      </ul>
        <form accept-charset="UTF-8" action="/search" class="command-bar-form" id="top_search_form" method="get">

<input type="text" data-hotkey=" s" name="q" id="js-command-bar-field" placeholder="Search or type a command" tabindex="1" autocapitalize="off"
    
    
      data-repo="louisremi/jquery.backgroundSize.js"
      data-branch="master"
      data-sha="fb6de243fd7666a9ccd84fe1c5e301591eefc1b9"
  >

    <input type="hidden" name="nwo" value="louisremi/jquery.backgroundSize.js" />

    <div class="select-menu js-menu-container js-select-menu search-context-select-menu">
      <span class="minibutton select-menu-button js-menu-target">
        <span class="js-select-button">This repository</span>
      </span>

      <div class="select-menu-modal-holder js-menu-content js-navigation-container">
        <div class="select-menu-modal">

          <div class="select-menu-item js-navigation-item js-this-repository-navigation-item selected">
            <span class="select-menu-item-icon octicon octicon-check"></span>
            <input type="radio" class="js-search-this-repository" name="search_target" value="repository" checked="checked" />
            <div class="select-menu-item-text js-select-button-text">This repository</div>
          </div> <!-- /.select-menu-item -->

          <div class="select-menu-item js-navigation-item js-all-repositories-navigation-item">
            <span class="select-menu-item-icon octicon octicon-check"></span>
            <input type="radio" name="search_target" value="global" />
            <div class="select-menu-item-text js-select-button-text">All repositories</div>
          </div> <!-- /.select-menu-item -->

        </div>
      </div>
    </div>

  <span class="octicon help tooltipped downwards" title="Show command bar help">
    <span class="octicon octicon-question"></span>
  </span>


  <input type="hidden" name="ref" value="cmdform">

</form>
    </div>

  </div>
</div>


      


          <div class="site" itemscope itemtype="http://schema.org/WebPage">
    
    <div class="pagehead repohead instapaper_ignore readability-menu">
      <div class="container">
        

<ul class="pagehead-actions">


  <li>
  <a href="/login?return_to=%2Flouisremi%2Fjquery.backgroundSize.js"
  class="minibutton with-count js-toggler-target star-button entice tooltipped upwards"
  title="You must be signed in to use this feature" rel="nofollow">
  <span class="octicon octicon-star"></span>Star
</a>
<a class="social-count js-social-count" href="/louisremi/jquery.backgroundSize.js/stargazers">
  155
</a>

  </li>

    <li>
      <a href="/login?return_to=%2Flouisremi%2Fjquery.backgroundSize.js"
        class="minibutton with-count js-toggler-target fork-button entice tooltipped upwards"
        title="You must be signed in to fork a repository" rel="nofollow">
        <span class="octicon octicon-git-branch"></span>Fork
      </a>
      <a href="/louisremi/jquery.backgroundSize.js/network" class="social-count">
        59
      </a>
    </li>
</ul>

        <h1 itemscope itemtype="http://data-vocabulary.org/Breadcrumb" class="entry-title public">
          <span class="repo-label"><span>public</span></span>
          <span class="mega-octicon octicon-repo"></span>
          <span class="author">
            <a href="/louisremi" class="url fn" itemprop="url" rel="author"><span itemprop="title">louisremi</span></a></span
          ><span class="repohead-name-divider">/</span><strong
          ><a href="/louisremi/jquery.backgroundSize.js" class="js-current-repository js-repo-home-link">jquery.backgroundSize.js</a></strong>

          <span class="page-context-loader">
            <img alt="Octocat-spinner-32" height="16" src="https://github.global.ssl.fastly.net/images/spinners/octocat-spinner-32.gif" width="16" />
          </span>

        </h1>
      </div><!-- /.container -->
    </div><!-- /.repohead -->

    <div class="container">

      <div class="repository-with-sidebar repo-container with-full-navigation">

        <div class="repository-sidebar">
            

<div class="repo-nav repo-nav-full js-repository-container-pjax js-octicon-loaders">
  <div class="repo-nav-contents">
    <ul class="repo-menu">
      <li class="tooltipped leftwards" title="Code">
        <a href="/louisremi/jquery.backgroundSize.js" aria-label="Code" class="js-selected-navigation-item selected" data-gotokey="c" data-pjax="true" data-selected-links="repo_source repo_downloads repo_commits repo_tags repo_branches /louisremi/jquery.backgroundSize.js">
          <span class="octicon octicon-code"></span> <span class="full-word">Code</span>
          <img alt="Octocat-spinner-32" class="mini-loader" height="16" src="https://github.global.ssl.fastly.net/images/spinners/octocat-spinner-32.gif" width="16" />
</a>      </li>

        <li class="tooltipped leftwards" title="Issues">
          <a href="/louisremi/jquery.backgroundSize.js/issues" aria-label="Issues" class="js-selected-navigation-item js-disable-pjax" data-gotokey="i" data-selected-links="repo_issues /louisremi/jquery.backgroundSize.js/issues">
            <span class="octicon octicon-issue-opened"></span> <span class="full-word">Issues</span>
            <span class='counter'>9</span>
            <img alt="Octocat-spinner-32" class="mini-loader" height="16" src="https://github.global.ssl.fastly.net/images/spinners/octocat-spinner-32.gif" width="16" />
</a>        </li>

      <li class="tooltipped leftwards" title="Pull Requests"><a href="/louisremi/jquery.backgroundSize.js/pulls" aria-label="Pull Requests" class="js-selected-navigation-item js-disable-pjax" data-gotokey="p" data-selected-links="repo_pulls /louisremi/jquery.backgroundSize.js/pulls">
            <span class="octicon octicon-git-pull-request"></span> <span class="full-word">Pull Requests</span>
            <span class='counter'>2</span>
            <img alt="Octocat-spinner-32" class="mini-loader" height="16" src="https://github.global.ssl.fastly.net/images/spinners/octocat-spinner-32.gif" width="16" />
</a>      </li>


    </ul>
    <div class="repo-menu-separator"></div>
    <ul class="repo-menu">

      <li class="tooltipped leftwards" title="Pulse">
        <a href="/louisremi/jquery.backgroundSize.js/pulse" aria-label="Pulse" class="js-selected-navigation-item " data-pjax="true" data-selected-links="pulse /louisremi/jquery.backgroundSize.js/pulse">
          <span class="octicon octicon-pulse"></span> <span class="full-word">Pulse</span>
          <img alt="Octocat-spinner-32" class="mini-loader" height="16" src="https://github.global.ssl.fastly.net/images/spinners/octocat-spinner-32.gif" width="16" />
</a>      </li>

      <li class="tooltipped leftwards" title="Graphs">
        <a href="/louisremi/jquery.backgroundSize.js/graphs" aria-label="Graphs" class="js-selected-navigation-item " data-pjax="true" data-selected-links="repo_graphs repo_contributors /louisremi/jquery.backgroundSize.js/graphs">
          <span class="octicon octicon-graph"></span> <span class="full-word">Graphs</span>
          <img alt="Octocat-spinner-32" class="mini-loader" height="16" src="https://github.global.ssl.fastly.net/images/spinners/octocat-spinner-32.gif" width="16" />
</a>      </li>

      <li class="tooltipped leftwards" title="Network">
        <a href="/louisremi/jquery.backgroundSize.js/network" aria-label="Network" class="js-selected-navigation-item js-disable-pjax" data-selected-links="repo_network /louisremi/jquery.backgroundSize.js/network">
          <span class="octicon octicon-git-branch"></span> <span class="full-word">Network</span>
          <img alt="Octocat-spinner-32" class="mini-loader" height="16" src="https://github.global.ssl.fastly.net/images/spinners/octocat-spinner-32.gif" width="16" />
</a>      </li>
    </ul>


  </div>
</div>

            <div class="only-with-full-nav">
              

  

<div class="clone-url open"
  data-protocol-type="http"
  data-url="/users/set_protocol?protocol_selector=http&amp;protocol_type=clone">
  <h3><strong>HTTPS</strong> clone URL</h3>

  <div class="clone-url-box">
    <input type="text" class="clone js-url-field"
           value="https://github.com/louisremi/jquery.backgroundSize.js.git" readonly="readonly">

    <span class="js-zeroclipboard url-box-clippy minibutton zeroclipboard-button" data-clipboard-text="https://github.com/louisremi/jquery.backgroundSize.js.git" data-copied-hint="copied!" title="copy to clipboard"><span class="octicon octicon-clippy"></span></span>
  </div>
</div>

  

<div class="clone-url "
  data-protocol-type="subversion"
  data-url="/users/set_protocol?protocol_selector=subversion&amp;protocol_type=clone">
  <h3><strong>Subversion</strong> checkout URL</h3>

  <div class="clone-url-box">
    <input type="text" class="clone js-url-field"
           value="https://github.com/louisremi/jquery.backgroundSize.js" readonly="readonly">

    <span class="js-zeroclipboard url-box-clippy minibutton zeroclipboard-button" data-clipboard-text="https://github.com/louisremi/jquery.backgroundSize.js" data-copied-hint="copied!" title="copy to clipboard"><span class="octicon octicon-clippy"></span></span>
  </div>
</div>



<p class="clone-options">You can clone with
    <a href="#" class="js-clone-selector" data-protocol="http">HTTPS</a>,
    <a href="#" class="js-clone-selector" data-protocol="subversion">Subversion</a>,
  and <a href="https://help.github.com/articles/which-remote-url-should-i-use">other methods.</a>
</p>


  <a href="http://windows.github.com" class="minibutton sidebar-button">
    <span class="octicon octicon-device-desktop"></span>
    Clone in Desktop
  </a>

                <a href="/louisremi/jquery.backgroundSize.js/archive/master.zip"
                   class="minibutton sidebar-button"
                   title="Download this repository as a zip file"
                   rel="nofollow">
                  <span class="octicon octicon-cloud-download"></span>
                  Download ZIP
                </a>
            </div>
        </div><!-- /.repository-sidebar -->

        <div id="js-repo-pjax-container" class="repository-content context-loader-container" data-pjax-container>
          
<div class="js-info-carrier" data-show-full-navigation="yes"></div>

<div class="repository-meta js-details-container ">
    <div class="repository-description js-details-show">
      <p>DEPRECATED, please use its successor: background-size polyfill</p>
    </div>

    <div class="repository-website js-details-show">
      <p><a href="https://github.com/louisremi/background-size-polyfill" rel="nofollow">https://github.com/louisremi/background-size-polyfill</a></p>
    </div>


</div>

<div class="capped-box overall-summary ">

  <div class="stats-switcher-viewport js-stats-switcher-viewport">

    <ul class="numbers-summary">
      <li class="commits">
        <a data-pjax href="/louisremi/jquery.backgroundSize.js/commits/master">
          <span class="num">
            <span class="octicon octicon-history"></span>
            9
          </span>
          commits
        </a>
      </li>
      <li>
        <a data-pjax href="/louisremi/jquery.backgroundSize.js/branches">
          <span class="num">
            <span class="octicon octicon-git-branch"></span>
            2
          </span>
          branches
        </a>
      </li>

      <li>
        <a data-pjax href="/louisremi/jquery.backgroundSize.js/releases">
          <span class="num">
            <span class="octicon octicon-tag"></span>
            0
          </span>
          releases
        </a>
      </li>

      <li>
        <a href="/louisremi/jquery.backgroundSize.js/contributors">
          <span class="num">
            <span class="octicon octicon-organization"></span>
            0
          </span>
          contributors
        </a>
      </li>
    </ul>

      <div class="repository-lang-stats">
        <ol class="repository-lang-stats-numbers">
          <li>
              <a href="/louisremi/jquery.backgroundSize.js/search?l=javascript">
                <span class="color-block language-color" style="background-color:#f15501;"></span>
                <span class="lang">JavaScript</span>
                <span class="percent">100%</span>
              </a>
          </li>
        </ol>
      </div>
  </div>

</div>

  <a href="#"
     class="repository-lang-stats-graph js-toggle-lang-stats tooltipped downwards"
     title="Show language statistics"
     style="background-color:#f15501">
  <span class="language-color" style="width:100%; background-color:#f15501;" itemprop="keywords">JavaScript</span>
  </a>




<div class="file-navigation in-mid-page">
    <a href="/louisremi/jquery.backgroundSize.js/compare" aria-label="Compare, review, create a pull request" class="minibutton compact primary tooltipped downwards" title="Compare &amp; review" data-pjax>
      <span class="octicon octicon-git-compare"></span>
    </a>

  


<div class="select-menu js-menu-container js-select-menu" >
  <span class="minibutton select-menu-button js-menu-target" data-hotkey="w"
    data-master-branch="master"
    data-ref="master" role="button" aria-label="Switch branches or tags">
    <span class="octicon octicon-git-branch"></span>
    <i>branch:</i>
    <span class="js-select-button">master</span>
  </span>

  <div class="select-menu-modal-holder js-menu-content js-navigation-container" data-pjax>

    <div class="select-menu-modal">
      <div class="select-menu-header">
        <span class="select-menu-title">Switch branches/tags</span>
        <span class="octicon octicon-remove-close js-menu-close"></span>
      </div> <!-- /.select-menu-header -->

      <div class="select-menu-filters">
        <div class="select-menu-text-filter">
          <input type="text" aria-label="Filter branches/tags" id="context-commitish-filter-field" class="js-filterable-field js-navigation-enable" placeholder="Filter branches/tags">
        </div>
        <div class="select-menu-tabs">
          <ul>
            <li class="select-menu-tab">
              <a href="#" data-tab-filter="branches" class="js-select-menu-tab">Branches</a>
            </li>
            <li class="select-menu-tab">
              <a href="#" data-tab-filter="tags" class="js-select-menu-tab">Tags</a>
            </li>
          </ul>
        </div><!-- /.select-menu-tabs -->
      </div><!-- /.select-menu-filters -->

      <div class="select-menu-list select-menu-tab-bucket js-select-menu-tab-bucket" data-tab-filter="branches">

        <div data-filterable-for="context-commitish-filter-field" data-filterable-type="substring">


            <div class="select-menu-item js-navigation-item ">
              <span class="select-menu-item-icon octicon octicon-check"></span>
              <a href="/louisremi/jquery.backgroundSize.js/tree/gh-pages" class="js-navigation-open select-menu-item-text js-select-button-text css-truncate-target" data-name="gh-pages" data-skip-pjax="true" rel="nofollow" title="gh-pages">gh-pages</a>
            </div> <!-- /.select-menu-item -->
            <div class="select-menu-item js-navigation-item selected">
              <span class="select-menu-item-icon octicon octicon-check"></span>
              <a href="/louisremi/jquery.backgroundSize.js/tree/master" class="js-navigation-open select-menu-item-text js-select-button-text css-truncate-target" data-name="master" data-skip-pjax="true" rel="nofollow" title="master">master</a>
            </div> <!-- /.select-menu-item -->
        </div>

          <div class="select-menu-no-results">Nothing to show</div>
      </div> <!-- /.select-menu-list -->

      <div class="select-menu-list select-menu-tab-bucket js-select-menu-tab-bucket" data-tab-filter="tags">
        <div data-filterable-for="context-commitish-filter-field" data-filterable-type="substring">


        </div>

        <div class="select-menu-no-results">Nothing to show</div>
      </div> <!-- /.select-menu-list -->

    </div> <!-- /.select-menu-modal -->
  </div> <!-- /.select-menu-modal-holder -->
</div> <!-- /.select-menu -->


  <div class="breadcrumb"><span class='repo-root js-repo-root'><span itemscope="" itemtype="http://data-vocabulary.org/Breadcrumb"><a href="/louisremi/jquery.backgroundSize.js" data-branch="master" data-direction="back" data-pjax="true" itemscope="url"><span itemprop="title">jquery.backgroundSize.js</span></a></span></span><span class="separator"> / </span><form action="/login?return_to=%2Flouisremi%2Fjquery.backgroundSize.js" class="js-new-blob-form tooltipped rightwards new-file-link" method="post" title="Sign in to make or propose changes"><span aria-label="Sign in to make or propose changes" class="js-new-blob-submit octicon octicon-file-add" data-test-id="create-new-git-file" role="button"></span></form></div>
</div>



<a href="/louisremi/jquery.backgroundSize.js/find/master"
  data-hotkey="t" style="display:none" data-pjax>Show File Finder</a>
<div class="bubble files-bubble">
  <table class="files" data-pjax>
    <thead>

        
  <div class="commit commit-tease js-details-container" >
      <a href="/louisremi/jquery.backgroundSize.js/commit/98b2559eb27a0c532ae3b64a2c457588884a2075" class="comment-count" anchor="comments" data-pjax>
        2 comments <span class='octicon octicon-comment'></span>
      </a>
    <p class="commit-title ">
        <a href="/louisremi/jquery.backgroundSize.js/commit/98b2559eb27a0c532ae3b64a2c457588884a2075" class="message" data-pjax="true">Mark plugin as deprecated</a>
        
    </p>
    <div class="commit-meta">
      <span class="js-zeroclipboard zeroclipboard-link" data-clipboard-text="98b2559eb27a0c532ae3b64a2c457588884a2075" data-copied-hint="copied!" title="Copy SHA"><span class="octicon octicon-clippy"></span></span>
      <a href="/louisremi/jquery.backgroundSize.js/commit/98b2559eb27a0c532ae3b64a2c457588884a2075" class="sha-block" data-pjax>latest commit <span class="sha">98b2559eb2</span></a>

      <div class="authorship">
        <img class="gravatar" height="20" src="https://secure.gravatar.com/avatar/1d924ae6b834d2c43d313a94137ac6fe?s=140&amp;d=https://a248.e.akamai.net/assets.github.com%2Fimages%2Fgravatars%2Fgravatar-user-420.png" width="20" />
        <span class="author-name">louisremi</span>
        authored <time class="js-relative-date updated" datetime="2012-12-04T14:57:52-08:00" title="2012-12-04 14:57:52">December 04, 2012</time>

      </div>
    </div>
  </div>

    </thead>

    
<tbody class=""
  data-url="/louisremi/jquery.backgroundSize.js/file-list/master">
    <tr class="alt">
      <td class="icon">
        <span class="octicon octicon-file-directory"></span>
        <img alt="Octocat-spinner-32" class="spinner" height="16" src="https://github.global.ssl.fastly.net/images/spinners/octocat-spinner-32.gif" width="16" />
      </td>
      <td class="content">
        <span class="css-truncate css-truncate-target"><a href="/louisremi/jquery.backgroundSize.js/tree/master/demo" class="js-directory-link" id="fe01ce2a7fbac8fafaed7c982a04e229-443837e386c2b121185c0969ac0c5e406167bd3d" title="demo">demo</a></span>
      </td>
      <td class="message">
        <span class="css-truncate css-truncate-target"><a href="/louisremi/jquery.backgroundSize.js/commit/312901ae6886bb8103e005ca949699778dbf258f" class="message" data-pjax="true" title="add a small condition to accomodate binpress">add a small condition to accomodate binpress</a></span>
      </td>
      <td class="age"><span class="css-truncate css-truncate-target"><time class="js-relative-date" datetime="2012-04-14T08:19:27-07:00" title="2012-04-14 08:19:27">April 14, 2012</time></span></td>
    </tr>
    <tr class="">
      <td class="icon">
        <span class="octicon octicon-file-text"></span>
        <img alt="Octocat-spinner-32" class="spinner" height="16" src="https://github.global.ssl.fastly.net/images/spinners/octocat-spinner-32.gif" width="16" />
      </td>
      <td class="content">
        <span class="css-truncate css-truncate-target"><a href="/louisremi/jquery.backgroundSize.js/blob/master/README.md" class="js-directory-link" id="04c6e90faac2675aa89e2176d2eec7d8-5bc923952c2144d320d16a11765e0488c3cdd9f3" title="README.md">README.md</a></span>
      </td>
      <td class="message">
        <span class="css-truncate css-truncate-target"><a href="/louisremi/jquery.backgroundSize.js/commit/98b2559eb27a0c532ae3b64a2c457588884a2075" class="message" data-pjax="true" title="Mark plugin as deprecated">Mark plugin as deprecated</a></span>
      </td>
      <td class="age"><span class="css-truncate css-truncate-target"><time class="js-relative-date" datetime="2012-12-04T14:57:52-08:00" title="2012-12-04 14:57:52">December 04, 2012</time></span></td>
    </tr>
    <tr class="alt">
      <td class="icon">
        <span class="octicon octicon-file-text"></span>
        <img alt="Octocat-spinner-32" class="spinner" height="16" src="https://github.global.ssl.fastly.net/images/spinners/octocat-spinner-32.gif" width="16" />
      </td>
      <td class="content">
        <span class="css-truncate css-truncate-target"><a href="/louisremi/jquery.backgroundSize.js/blob/master/jquery.backgroundSize.js" class="js-directory-link" id="6b20ae9e60b2e6f44ae8902378c7e0d2-741763292d1d65f650e9d73c91cbfc5a3ac9ea1c" title="jquery.backgroundSize.js">jquery.backgroundSize.js</a></span>
      </td>
      <td class="message">
        <span class="css-truncate css-truncate-target"><a href="/louisremi/jquery.backgroundSize.js/commit/2c3265616294877e3a60bbd986e258fec3b683fb" class="message" data-pjax="true" title="Tune the backgroundImage hook to save some bytes">Tune the backgroundImage hook to save some bytes</a></span>
      </td>
      <td class="age"><span class="css-truncate css-truncate-target"><time class="js-relative-date" datetime="2012-06-03T07:30:58-07:00" title="2012-06-03 07:30:58">June 03, 2012</time></span></td>
    </tr>
</tbody>

  </table>
</div>

  <div id="readme" class="clearfix announce instapaper_body md">
    <span class="name"><span class="octicon octicon-book"></span> README.md</span><article class="markdown-body entry-content" itemprop="mainContentOfPage"><h1>
<a name="jquerybackgroundsizejs-deprecated" class="anchor" href="#jquerybackgroundsizejs-deprecated"><span class="octicon octicon-link"></span></a>jquery.backgroundSize.js <strong>DEPRECATED</strong>
</h1>

<p><strong>This plugin has been deprecated</strong>, please use its <a href="https://github.com/louisremi/background-size-polyfill">background-size polyfill</a> successor.</p>

<p>A jQuery cssHook adding support for "cover" and "contain" to IE6-7-8, in 1.5K</p>

<h2>
<a name="introduction" class="anchor" href="#introduction"><span class="octicon octicon-link"></span></a>Introduction</h2>

<p><a href="http://louisremi.github.com/jquery.backgroundSize.js/demo/">Demo</a></p>

<p><strong>Progressive Enhancement</strong> is the mantra I live by. It means <em>"Have fun with CSS3 and don't worry about IE6-7-8 users; they'll never notice they're missing out on your gorgeous text-shadows and gradients, anyway"</em>.</p>

<p>All was well until I discovered the elegance of <code>background-size: cover;</code> and <code>background-size: contain;</code>.
The first one, for instance, allows an image to completely cover a background, 
<strong>without</strong> having to send a 1920x1080 background image down the pipes.</p>

<p>Unfortunately, they don't degrade gracefully: websites would likely appear broken to IE6-7-8 users :-( 
...unless you use this cssHook!</p>

<h2>
<a name="how-does-it-work" class="anchor" href="#how-does-it-work"><span class="octicon octicon-link"></span></a>How does it work?</h2>

<p>Set the <code>background-size</code> just like any other style property with jQuery:</p>

<div class="highlight"><pre><span class="nx">$</span><span class="p">(</span><span class="nx">elem</span><span class="p">).</span><span class="nx">css</span><span class="p">(</span> <span class="s2">"background-size"</span><span class="p">,</span> <span class="s2">"cover"</span> <span class="p">);</span>
</pre></div>

<p>In browsers that don't implement it natively, an <code>&lt;img/&gt;</code> will be inserted in the background of <code>elem</code> and emulate the <code>cover</code> or <code>contain</code> value.</p>

<h2>
<a name="limitations" class="anchor" href="#limitations"><span class="octicon octicon-link"></span></a>Limitations</h2>

<p>Calculating the displayed position and size of the background-image of an element is quite complex and function of numerous parameters:  </p>

<ul>
<li>the size of the element itself<br>
</li>
<li>the size of the image<br>
</li>
<li>the values of background-[size/position/clip/origin/attachment/scroll]</li>
</ul><p>It is thus impossible to emulate <code>background-size</code> completely and perfectly. But it's still possible to enjoy the main features:  </p>

<ul>
<li>correct position and size of the background image<br>
</li>
<li>updated position and size on browser resize<br>
</li>
<li>updated image, position and size when the background-image is modified using <code>$(elem).css("background-image", "differentImage.jpg");</code>
</li>
</ul><p>The following style properties, values or behavior aren't supported:  </p>

<ul>
<li>values other than <code>cover</code> or <code>contain</code> in <code>background-size</code><br>
</li>
<li>multiple backgrounds (although the :after trick can still be used)<br>
</li>
<li>4 values syntax of <code>background-position</code><br>
</li>
<li>lengths (px, em, etc.) in <code>background-position</code> (only percentages and keywords such as <code>center</code> work)<br>
</li>
<li>any <code>repeat</code> value in <code>background-repeat</code><br>
</li>
<li>non-default values of background-[clip/origin/attachment/scroll]<br>
</li>
<li>updated image size when the size of the element is modified</li>
</ul><p>Removing any of these limitations is probably just one fork away...</p>

<h2>
<a name="development-vs-production" class="anchor" href="#development-vs-production"><span class="octicon octicon-link"></span></a>Development vs. Production</h2>

<p>The elements targeted by this plugin should be positionned (<code>position: relative/absolute/fixed;</code> but not <code>static</code>) and have a z-index. 
If not, they will be given a <code>position: relative;</code> and <code>z-index: 0;</code>.</p>

<p>In some cases this could potentially alter the layout of your page in IE6-7-8.
To help you spot problems earlier, you can use a flag that will turn ON emulation of <code>background-size</code> in all browsers:</p>

<div class="highlight"><pre><span class="c">&lt;!-- The flag should be inserted before loading the script --&gt;</span>
<span class="nt">&lt;script&gt;</span><span class="nx">$</span><span class="p">.</span><span class="nx">debugBGS</span> <span class="o">=</span> <span class="kc">true</span><span class="p">;</span><span class="nt">&lt;/script&gt;</span>
<span class="nt">&lt;script </span><span class="na">src=</span><span class="s">"/path/to/jquery.backgroundSize.js"</span><span class="nt">&gt;&lt;/script&gt;</span>
</pre></div>

<p>Switch to the following snippet before deploying your code to a production environment:</p>

<div class="highlight"><pre><span class="c">&lt;!--[if lt IE 9]&gt; &lt;script src="/path/to/jquery.backgroundSize.min.js"&gt;&lt;/script&gt; &lt;![endif]--&gt;</span>
</pre></div>

<h2>
<a name="refreshing-a-background" class="anchor" href="#refreshing-a-background"><span class="octicon octicon-link"></span></a>Refreshing a background</h2>

<p>There are several cases that can cause an element to be resized and require its background to be refreshed
(e.g. modifying the size of its content or animating it).
This plugin includes a helper for that purpose: <code>$.refreshBackgroundDimensions( elem );</code>. Here's how to use it during an animation:</p>

<div class="highlight"><pre><span class="nx">$</span><span class="p">(</span><span class="nx">elem</span><span class="p">).</span><span class="nx">animate</span><span class="p">({</span> <span class="nx">height</span><span class="o">:</span> <span class="s2">"+=100"</span> <span class="p">},</span> <span class="p">{</span>
    <span class="nx">step</span><span class="o">:</span> <span class="kd">function</span><span class="p">()</span> <span class="p">{</span> <span class="nx">$</span><span class="p">.</span><span class="nx">refreshBackgroundDimensions</span><span class="p">(</span> <span class="k">this</span> <span class="p">);</span> <span class="p">}</span>
<span class="p">});</span>
</pre></div>

<h2>
<a name="license" class="anchor" href="#license"><span class="octicon octicon-link"></span></a>License</h2>

<p>MIT Licensed <a href="http://louisremi.mit-license.org/">http://louisremi.mit-license.org/</a>, by <a href="http://twitter.com/louis_remi">@louis_remi</a></p></article>
  </div>


        </div>

      </div><!-- /.repo-container -->
      <div class="modal-backdrop"></div>
    </div><!-- /.container -->
  </div><!-- /.site -->


    </div><!-- /.wrapper -->

      <div class="container">
  <div class="site-footer">
    <ul class="site-footer-links right">
      <li><a href="https://status.github.com/">Status</a></li>
      <li><a href="http://developer.github.com">API</a></li>
      <li><a href="http://training.github.com">Training</a></li>
      <li><a href="http://shop.github.com">Shop</a></li>
      <li><a href="/blog">Blog</a></li>
      <li><a href="/about">About</a></li>

    </ul>

    <a href="/">
      <span class="mega-octicon octicon-mark-github"></span>
    </a>

    <ul class="site-footer-links">
      <li>&copy; 2013 <span title="0.07675s from github-fe125-cp1-prd.iad.github.net">GitHub</span>, Inc.</li>
        <li><a href="/site/terms">Terms</a></li>
        <li><a href="/site/privacy">Privacy</a></li>
        <li><a href="/security">Security</a></li>
        <li><a href="/contact">Contact</a></li>
    </ul>
  </div><!-- /.site-footer -->
</div><!-- /.container -->


    <div class="fullscreen-overlay js-fullscreen-overlay" id="fullscreen_overlay">
  <div class="fullscreen-container js-fullscreen-container">
    <div class="textarea-wrap">
      <textarea name="fullscreen-contents" id="fullscreen-contents" class="js-fullscreen-contents" placeholder="" data-suggester="fullscreen_suggester"></textarea>
          <div class="suggester-container">
              <div class="suggester fullscreen-suggester js-navigation-container" id="fullscreen_suggester"
                 data-url="/louisremi/jquery.backgroundSize.js/suggestions/commit">
              </div>
          </div>
    </div>
  </div>
  <div class="fullscreen-sidebar">
    <a href="#" class="exit-fullscreen js-exit-fullscreen tooltipped leftwards" title="Exit Zen Mode">
      <span class="mega-octicon octicon-screen-normal"></span>
    </a>
    <a href="#" class="theme-switcher js-theme-switcher tooltipped leftwards"
      title="Switch themes">
      <span class="octicon octicon-color-mode"></span>
    </a>
  </div>
</div>



    <div id="ajax-error-message" class="flash flash-error">
      <span class="octicon octicon-alert"></span>
      <a href="#" class="octicon octicon-remove-close close ajax-error-dismiss"></a>
      Something went wrong with that request. Please try again.
    </div>

    
  </body>
</html>

