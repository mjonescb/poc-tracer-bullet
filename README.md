# Description

This repository holds a proof of concept. It aims to explore an implementation of a tracer bullet, given certain technical constraints.

# Background

A key business process runs once a day. It consists of multiple individually deployable components, and is of high importance. In order to support a high rate of change to the process, we need to catch issues/bugs/failures/regressions as early as we can, to shorten feedback cycles. 

The approach is to run an automated, frequent, and system-wide test on a live (non-local) environment. The component that initiates the process is provided a small synthetic workload, after which all the components involved will have to work in this synthetic fashion until the end of the process is reached. A monitoring system, that is shared by all components, will be used to to detect failure. 

Data integrity has to be ensured. That means that when a tracer bullet payload is being processed by an application, any dependencies that can generate side-effects, are swapped out with [no-ops](https://en.wikipedia.org/wiki/NOP_). When a subsequent real payload is received, the no-ops will have to make way for the actual implementations, and so forth. 

# Technical constraints

- Unity 5.0
- .NET full framework

# Proof of concept

- [ ] Depending on the headers/payload of the input, alternate between no-op and live implementations
- [ ] Aside from a central place, dependencies have no notion of dealing with no-op or live implementations

# Tracer bullet 

> From ThePragmaticProgrammer; a method of software engineering that is likened to firing a machine gun at night. You can either know exactly where you are, where the target is and do the the maths to work out how to point it and hope you're right... or you can load every other bullet with tracer (which glows in the dark) and then just turn the outgoing line of bullets (which you can now see) onto the target.

> Programming-wise, it involves short cycles of development, then delivery and asking the customer if it's closer or further from what they think the target is... rather than finding out right at the end that you've misunderstood something.

[from c2.com](http://wiki.c2.com/?TracerBullets)

# Sample output

```
[MetricsPublisher]: process.started
[MetricsPublisher]: queue.message.received [#tracerbullet:False]
[MetricsPublisher]: message.processing.started
[MetricsPublisher]: message.processing.finished
[MetricsPublisher]: queue.message.deleted
[MetricsPublisher]: queue.message.received [#tracerbullet:True]
[NoopPublisher]: message.processing.started
[NoopPublisher]: message.processing.finished
[MetricsPublisher]: queue.message.deleted
[MetricsPublisher]: process.finished
```
